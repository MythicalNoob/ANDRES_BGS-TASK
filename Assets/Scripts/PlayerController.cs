using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del jugador
    public List<Sprite> items = new List<Sprite>();
    public List<GameObject> clothes = new List<GameObject>();
    public List<Button> inventory = new List<Button>();
    public bool[] inventorySpace = new bool[9] { false, false, false, false, false, false, false, false, false };
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    public Button sell;
    public Button close;

    int itemBoughtID = 0;
    private int[] inventoryIDs = new int[9] { 0,0,0,0,0,0,0,0,0 };
    GameManager manager;
    bool alreadyAdded = false;  
    public List<Sprite> idles = new List<Sprite>();

    public static bool didBuy = false;

    public TextMeshProUGUI innervoice;
    public GameObject buttons;
    public GameObject innervoicePanel;
    public int spaceSell;

    int myID = 0;

    string[] IDsText = new string[11] {
        "Cowboy hat - 1.99",
        "Lucky hat - 2.99",
        "Pumpking hat - 6.99",
        "Witcher hat - 10.99",
        "Clown's mask - 15.00",
        "Witch's robe - 1.99",
        "Suit - 2.99",
        "Clown - 7.99",
        "Brown pants - 0.99",
        "Purpple pants - 0.99",
        "Emerald earrings - 39.99"
    };

    private void Awake()
    {

        for (int i = 0; i < inventory.Count; i++)
        {
            var item = inventory[i].GetComponent<UnityEngine.UI.Image>();
            item.sprite = items[11];

            inventory[i].interactable = false;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        manager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // Obtener el input del jugador
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Debug.Log(movement.sqrMagnitude + "el movimiento o speed");

        // Normalizar el vector de movimiento para evitar movimientos diagonales más rápidos
        movement = new Vector2(moveX, moveY).normalized;

        if(didBuy == true)
        {
            itemBoughtID = GameManager.itemID;

            for(int i = 0;i < inventoryIDs.Length;i++)
            {
                if (inventoryIDs[i] == itemBoughtID)
                {
                    alreadyAdded = true;
                    Debug.Log("esta agregado");
                }
            }
            Debug.Log(alreadyAdded);

            if (alreadyAdded == false)
            {
                Debug.Log("entre aqui al id");
                Debug.Log("Tamaño de inventoryIDs: " + inventoryIDs.Length);
                for (int i = 0; i < inventoryIDs.Length; i++)
                {
                    Debug.Log("en el for del id");
                    if (inventoryIDs[i] == 0)
                    {
                        Debug.Log("si hay id disponible");
                        inventoryIDs[i] = itemBoughtID;
                        Debug.Log(i + "es aqui el indice del id");
                        break;
                    }
                }
            }

            for (int i = 0; i < inventorySpace.Length; i++)
            {
                if (inventorySpace[i] == false)
                {
                    var item = inventory[i].GetComponent<UnityEngine.UI.Image>();
                    item.sprite = items[itemBoughtID - 1];
                    inventorySpace[i] = true;
                    inventory[i].interactable = true;
                    Debug.Log(i + "es aqui el indice del boton");
                    break;
                }
            }

            didBuy = false;
        }

        close.onClick.AddListener(() => { 
            GameManager.didSell = false;
            innervoicePanel.SetActive(false);
            buttons.SetActive(true);
            sell.gameObject.SetActive(false);
            close.gameObject.SetActive(false);
        
        });

        sell.onClick.AddListener(() =>
        {
            for (int i = 0; i < inventoryIDs.Length; i++)
            {
                if (inventoryIDs[i] == myID)
                {
                    inventoryIDs[i] = 0;
                    inventorySpace[i] = false;
                    var item = inventory[i].GetComponent<UnityEngine.UI.Image>();
                    item.sprite = items[11];
                    inventory[i].interactable = false;
                    clothes[myID - 1].SetActive(false);
                    GameManager.itemsBought--;
                    break;
                }
            }

        });

        inventory[0].onClick.AddListener(() =>
        {
            if (GameManager.didSell == true)
            {
                myID = inventoryIDs[0];
                spaceSell = 0;
                innervoice.text = IDsText[myID - 1]; 
            }
            else
            {
                myID = inventoryIDs[0];

                if(myID <= 4)
                {
                    clothes[0].SetActive(false);
                    clothes[1].SetActive(false);
                    clothes[2].SetActive(false);
                    clothes[3].SetActive(false);
                    clothes[4].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if(myID >= 5 && myID <= 7)
                {
                    clothes[5].SetActive(false);
                    clothes[6].SetActive(false);
                    clothes[7].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID == 8  || myID == 9)
                {
                    clothes[8].SetActive(false);
                    clothes[9].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID == 10)
                {
                    clothes[10].SetActive(true);
                }
            }
        });
        inventory[1].onClick.AddListener(() =>
        {
            if (GameManager.didSell == true)
            {
                myID = inventoryIDs[1];
                spaceSell = 1;
                innervoice.text = IDsText[myID - 1];
            }
            else
            {
                myID = inventoryIDs[1];

                if (myID <= 4)
                {
                    clothes[0].SetActive(false);
                    clothes[1].SetActive(false);
                    clothes[2].SetActive(false);
                    clothes[3].SetActive(false);
                    clothes[4].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID >= 5 && myID <= 7)
                {
                    clothes[5].SetActive(false);
                    clothes[6].SetActive(false);
                    clothes[7].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID == 8 || myID == 9)
                {
                    clothes[8].SetActive(false);
                    clothes[9].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID == 10)
                {
                    clothes[10].SetActive(true);
                }
            }
        });
        inventory[2].onClick.AddListener(() =>
        {
            if (GameManager.didSell == true)
            {
                myID = inventoryIDs[2];
                spaceSell = 2;
                innervoice.text = IDsText[myID - 1];
            }
            else
            {
                myID = inventoryIDs[2];

                if (myID <= 4)
                {
                    clothes[0].SetActive(false);
                    clothes[1].SetActive(false);
                    clothes[2].SetActive(false);
                    clothes[3].SetActive(false);
                    clothes[4].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID >= 5 && myID <= 7)
                {
                    clothes[5].SetActive(false);
                    clothes[6].SetActive(false);
                    clothes[7].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID == 8 || myID == 9)
                {
                    clothes[8].SetActive(false);
                    clothes[9].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID == 10)
                {
                    clothes[10].SetActive(true);
                }
            }
        });
        inventory[3].onClick.AddListener(() =>
        {
            if (GameManager.didSell == true)
            {
                myID = inventoryIDs[3];
                spaceSell = 3;
                innervoice.text = IDsText[myID - 1];
            }
            else
            {
                myID = inventoryIDs[3];

                if (myID <= 4)
                {
                    clothes[0].SetActive(false);
                    clothes[1].SetActive(false);
                    clothes[2].SetActive(false);
                    clothes[3].SetActive(false);
                    clothes[4].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID >= 5 && myID <= 7)
                {
                    clothes[5].SetActive(false);
                    clothes[6].SetActive(false);
                    clothes[7].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID == 8 || myID == 9)
                {
                    clothes[8].SetActive(false);
                    clothes[9].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID == 10)
                {
                    clothes[10].SetActive(true);
                }
            }
        });
        inventory[4].onClick.AddListener(() =>
        {
            if (GameManager.didSell == true)
            {
                myID = inventoryIDs[4];
                spaceSell = 4;
                innervoice.text = IDsText[myID - 1];
            }
            else
            {
                myID = inventoryIDs[4];

                if (myID <= 4)
                {
                    clothes[0].SetActive(false);
                    clothes[1].SetActive(false);
                    clothes[2].SetActive(false);
                    clothes[3].SetActive(false);
                    clothes[4].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID >= 5 && myID <= 7)
                {
                    clothes[5].SetActive(false);
                    clothes[6].SetActive(false);
                    clothes[7].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID == 8 || myID == 9)
                {
                    clothes[8].SetActive(false);
                    clothes[9].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID == 10)
                {
                    clothes[10].SetActive(true);
                }
            }
        });
        inventory[5].onClick.AddListener(() =>
        {
            if (GameManager.didSell == true)
            {
                myID = inventoryIDs[5];
                spaceSell = 5;
                innervoice.text = IDsText[myID - 1];
            }
            else
            {
                myID = inventoryIDs[5];

                if (myID <= 4)
                {
                    clothes[0].SetActive(false);
                    clothes[1].SetActive(false);
                    clothes[2].SetActive(false);
                    clothes[3].SetActive(false);
                    clothes[4].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID >= 5 && myID <= 7)
                {
                    clothes[5].SetActive(false);
                    clothes[6].SetActive(false);
                    clothes[7].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID == 8 || myID == 9)
                {
                    clothes[8].SetActive(false);
                    clothes[9].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID == 10)
                {
                    clothes[10].SetActive(true);
                }
            }
        });
        inventory[6].onClick.AddListener(() =>
        {
            if (GameManager.didSell == true)
            {
                myID = inventoryIDs[6];
                spaceSell = 6;
                innervoice.text = IDsText[myID - 1];
            }
            else
            {
                myID = inventoryIDs[6];

                if (myID <= 4)
                {
                    clothes[0].SetActive(false);
                    clothes[1].SetActive(false);
                    clothes[2].SetActive(false);
                    clothes[3].SetActive(false);
                    clothes[4].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID >= 5 && myID <= 7)
                {
                    clothes[5].SetActive(false);
                    clothes[6].SetActive(false);
                    clothes[7].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID == 8 || myID == 9)
                {
                    clothes[8].SetActive(false);
                    clothes[9].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID == 10)
                {
                    clothes[10].SetActive(true);
                }
            }
        });
        inventory[7].onClick.AddListener(() =>
        {
            if (GameManager.didSell == true)
            {
                myID = inventoryIDs[7];
                spaceSell = 7;
                innervoice.text = IDsText[myID - 1];
            }
            else
            {
                myID = inventoryIDs[7];

                if (myID <= 4)
                {
                    clothes[0].SetActive(false);
                    clothes[1].SetActive(false);
                    clothes[2].SetActive(false);
                    clothes[3].SetActive(false);
                    clothes[4].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID >= 5 && myID <= 7)
                {
                    clothes[5].SetActive(false);
                    clothes[6].SetActive(false);
                    clothes[7].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID == 8 || myID == 9)
                {
                    clothes[8].SetActive(false);
                    clothes[9].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID == 10)
                {
                    clothes[10].SetActive(true);
                }
            }
        });
        inventory[8].onClick.AddListener(() =>
        {
            if (GameManager.didSell == true)
            {
                myID = inventoryIDs[8];
                spaceSell = 8;
                innervoice.text = IDsText[myID - 1];
            }
            else
            {
                myID = inventoryIDs[8];

                if (myID <= 4)
                {
                    clothes[0].SetActive(false);
                    clothes[1].SetActive(false);
                    clothes[2].SetActive(false);
                    clothes[3].SetActive(false);
                    clothes[4].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID >= 5 && myID <= 7)
                {
                    clothes[5].SetActive(false);
                    clothes[6].SetActive(false);
                    clothes[7].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID == 8 || myID == 9)
                {
                    clothes[8].SetActive(false);
                    clothes[9].SetActive(false);

                    clothes[myID - 1].SetActive(true);
                }
                else if (myID == 10)
                {
                    clothes[10].SetActive(true);
                }
            }
        });

    }

    void FixedUpdate()
    {
        // Mover al jugador basado en el vector de movimiento
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);

    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Keeper")
        {
            innervoice.text = "What would you like to do?...";
            manager.StoreKeeper();
            buttons.SetActive(true);
        }
        else if (col.gameObject.tag == "clown")
        {
            StartCoroutine(MyVoice("That's scary..."));
        }
        else if (col.gameObject.tag == "witch")
        {
            StartCoroutine(MyVoice("Cool..."));
        }
        else if (col.gameObject.tag == "grey witch")
        {
            StartCoroutine(MyVoice("Cooler..."));
        }
        else if (col.gameObject.tag == "earing")
        {
            StartCoroutine(MyVoice("Mmmh interesting..."));
        }
        else if (col.gameObject.tag == "hatluck")
        {
            StartCoroutine(MyVoice("Maybe I win the lottery..."));
        }
        else if (col.gameObject.tag == "pumpking")
        {
            StartCoroutine(MyVoice("I'm craving a pie..."));
        }
    }

    IEnumerator MyVoice(string text)
    {
        innervoicePanel.SetActive(true);
        buttons.SetActive(false);
        innervoice.text = text;

        yield return new WaitForSeconds(3.0f);
        innervoicePanel.SetActive(false);
    }
}
