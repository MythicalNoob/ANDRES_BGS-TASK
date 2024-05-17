using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;

public class StoreManager : MonoBehaviour
{
    #region variables

    [Header("<<UI>>")]
    public List<Sprite> items = new List<Sprite>();
    public List<Sprite> hats = new List<Sprite>();
    public List<Sprite> shirts = new List<Sprite>();
    public List<Sprite> pants = new List<Sprite>();
    public List<Sprite> jewls = new List<Sprite>();
    public List<Button> StorageHolders = new List<Button>();
    public Button hat;
    public Button shirt;
    public Button pant;
    public Button jewl;
    public Button buy;
    public UnityEngine.UI.Image itemHolder;
    public TextMeshProUGUI keeperVoice;
    public TextMeshProUGUI itemInfo;


    int buttonItemSelector = 0;
    int selector = 0;//hat=1 shirt=2 pants=3 jewl=4
    
    #endregion

    private void Awake()
    {
        AssignButtons();
        selector = 1;

        selector = 1;
        var myID = 0;
        var myID2 = 0;
        var myID3 = 0;
        var myID4 = 0;
        var myID5 = 0;

        for (int i = 0; i < GameManager.IDs.Length; i++)
        {
            if (GameManager.IDs[i] == 1)
            {
                myID = 1;
            }
            else if (GameManager.IDs[i] == 2)
            {
                myID2 = 2;
            }
            else if (GameManager.IDs[i] == 3)
            {
                myID3 = 3;
            }
            else if (GameManager.IDs[i] == 4)
            {
                myID4 = 4;
            }
            else if (GameManager.IDs[i] == 5)
            {
                myID5 = 5;
            }
        }

        var item = StorageHolders[0].GetComponent<UnityEngine.UI.Image>();

        if (myID == 1)
        {

            item.sprite = hats[0];
        }
        else
        {
            item.sprite = items[11];
        }

        item = StorageHolders[1].GetComponent<UnityEngine.UI.Image>();

        if (myID2 == 2)
        {

            item.sprite = hats[1];
        }
        else
        {
            item.sprite = items[11];
        }

        item = StorageHolders[2].GetComponent<UnityEngine.UI.Image>();

        if (myID3 == 3)
        {

            item.sprite = hats[2];
        }
        else
        {
            item.sprite = items[11];
        }

        item = StorageHolders[3].GetComponent<UnityEngine.UI.Image>();

        if (myID4 == 4)
        {

            item.sprite = hats[3];
        }
        else
        {
            item.sprite = items[11];
        }

        item = StorageHolders[4].GetComponent<UnityEngine.UI.Image>();

        if (myID5 == 5)
        {

            item.sprite = hats[4];
        }
        else
        {
            item.sprite = items[11];
        }


        SetInventory();
    }

    private void Start()
    {
        selector = 1;

        if (StorageHolders.Count == 0)
        {
            Debug.LogError("StorageHolders list is empty!");
            return;
        }

        if (keeperVoice == null)
        {
            Debug.LogError("keeperVoice is not assigned!");
            return;
        }

        if (itemHolder == null)
        {
            Debug.LogError("itemHolder is not assigned!");
            return;
        }

        if (hat == null || shirt == null || pant == null || jewl == null)
        {
            Debug.LogError("One of the category buttons is not assigned!");
            return;
        }

        buy.onClick.AddListener(() =>
        {
            BuyMyItem();
        });


    }

    void SetInventory()
    {
        var myID = 0;

        if (selector == 1)//cowboy0 lucky1 pump2 witch3 clown4 
        {
            
            StorageHolders[0].onClick.AddListener(() =>
            {
                buttonItemSelector = 0;

                for(int i = 0; i < GameManager.IDs.Length; i++)
                {
                    if(GameManager.IDs[i] == 1)
                    {
                        myID = 1;
                    }
                } 

                if(myID == 1)
                {
                    itemInfo.text = "Cowboy hat - 3.99";
                    itemHolder.sprite = items[0];
                    GameManager.itemID = 1;
                }
                else
                {
                    itemInfo.text = "Not Available";
                    itemHolder.sprite = items[11];
                }
                
            });
            StorageHolders[1].onClick.AddListener(() =>
            {
                buttonItemSelector = 1;

                for (int i = 0; i < GameManager.IDs.Length; i++)
                {
                    if(GameManager.IDs[i] == 2)
                    {
                        myID = 2;
                    }
                } 

                if(myID == 2)
                {
                    itemInfo.text = "Lucky hat - 5.99";
                    itemHolder.sprite = items[1];
                    GameManager.itemID = 2;
                }
                else
                {
                    itemInfo.text = "Not Available";
                    itemHolder.sprite = items[11];
                }
            });
            StorageHolders[2].onClick.AddListener(() =>
            {
                buttonItemSelector = 2;
                for (int i = 0; i < GameManager.IDs.Length; i++)
                {
                    if (GameManager.IDs[i] == 3)
                    {
                        myID = 3;
                    }
                }

                if (myID == 3)
                {
                    itemInfo.text = "Pumpking hat - 10.99";
                    itemHolder.sprite = items[2];
                    GameManager.itemID = 3;
                }
                else
                {
                    itemInfo.text = "Not Available";
                    itemHolder.sprite = items[11];
                }
            });
            StorageHolders[3].onClick.AddListener(() =>
            {
                buttonItemSelector = 3;
                for (int i = 0; i < GameManager.IDs.Length; i++)
                {
                    if(GameManager.IDs[i] == 4)
                    {
                        myID = 4;
                    }
                } 

                if(myID == 4)
                {
                    itemInfo.text = "Witcher hat - 15.99";
                    itemHolder.sprite = items[3];
                    GameManager.itemID = 4;
                }
                else
                {
                    itemInfo.text = "Not Available";
                    itemHolder.sprite = items[11];
                }
            });
            StorageHolders[4].onClick.AddListener(() =>
            {
                buttonItemSelector = 4;
                for (int i = 0; i < GameManager.IDs.Length; i++)
                {
                    if(GameManager.IDs[i] == 5)
                    {
                        myID = 5;
                    }
                } 

                if(myID == 5)
                {
                    itemInfo.text = "Clown's mask - 20.00";
                    itemHolder.sprite = items[4];
                    GameManager.itemID = 5;
                }
                else
                {
                    itemInfo.text = "Not Available";
                    itemHolder.sprite = items[11];
                }
            });
        }
        else if (selector == 2)//witch5 suit6 clown7
        {
            StorageHolders[0].onClick.AddListener(() =>
            {
                buttonItemSelector = 0;
                for (int i = 0; i < GameManager.IDs.Length; i++)
                {
                    if(GameManager.IDs[i] == 6)
                    {
                        myID = 6;
                    }
                } 

                if(myID == 6)
                {
                    itemInfo.text = "Witch's robe - 3.99";
                    itemHolder.sprite = items[5];
                    GameManager.itemID = 6;
                }
                else
                {
                    itemInfo.text = "Not Available";
                    itemHolder.sprite = items[11];
                }
            });
            StorageHolders[1].onClick.AddListener(() =>
            {
                buttonItemSelector = 1;
                for (int i = 0; i < GameManager.IDs.Length; i++)
                {
                    if(GameManager.IDs[i] == 7)
                    {
                        myID = 7;
                    }
                } 

                if(myID == 7)
                {
                    itemInfo.text = "Suit - 5.99";
                    itemHolder.sprite = items[6];
                    GameManager.itemID = 7;
                }
                else
                {
                    itemInfo.text = "Not Available";
                    itemHolder.sprite = items[11];
                }
            });
            StorageHolders[2].onClick.AddListener(() =>
            {
                buttonItemSelector = 2;
                for (int i = 0; i < GameManager.IDs.Length; i++)
                {
                    if(GameManager.IDs[i] == 8)
                    {
                        myID = 8;
                    }
                } 

                if(myID == 8)
                {
                    itemInfo.text = "Clown - 10.99";
                    itemHolder.sprite = items[7];
                    GameManager.itemID = 8;
                }
                else
                {
                    itemInfo.text = "Not Available";
                    itemHolder.sprite = items[11];
                }
            });
            StorageHolders[3].onClick.AddListener(() =>
            {
                buttonItemSelector = 3;
                itemInfo.text = "Not Available";
                itemHolder.sprite = items[11];
            });
            StorageHolders[4].onClick.AddListener(() =>
            {
                buttonItemSelector = 4;
                itemInfo.text = "Not Available";
                itemHolder.sprite = items[11];
            });
        }
        else if (selector == 3)//brown8 purpple9
        {
            StorageHolders[0].onClick.AddListener(() =>
            {
                buttonItemSelector = 0;
                for (int i = 0; i < GameManager.IDs.Length; i++)
                {
                    if(GameManager.IDs[i] == 9)
                    {
                        myID = 9;
                    }
                } 

                if(myID == 9)
                {
                    itemInfo.text = "Brown pants - 2.99";
                    itemHolder.sprite = items[8];
                    GameManager.itemID = 9;
                }
                else
                {
                    itemInfo.text = "Not Available";
                    itemHolder.sprite = items[11];
                }
            });
            StorageHolders[1].onClick.AddListener(() =>
            {
                buttonItemSelector = 1;
                for (int i = 0; i < GameManager.IDs.Length; i++)
                {
                    if(GameManager.IDs[i] == 10)
                    {
                        myID = 10;
                    }
                } 

                if(myID == 10)
                {
                    itemInfo.text = "Purpple pants - 2.99";
                    itemHolder.sprite = items[9];
                    GameManager.itemID = 10;
                }
                else
                {
                    itemInfo.text = "Not Available";
                    itemHolder.sprite = items[11];
                }
            });
            StorageHolders[2].onClick.AddListener(() =>
            {
                buttonItemSelector = 2;
                itemInfo.text = "Not Available";
                itemHolder.sprite = items[11];
            });
            StorageHolders[3].onClick.AddListener(() =>
            {
                buttonItemSelector = 3;
                itemInfo.text = "Not Available";
                itemHolder.sprite = items[11];
            });
            StorageHolders[4].onClick.AddListener(() =>
            {
                buttonItemSelector = 4;
                itemInfo.text = "Not Available";
                itemHolder.sprite = items[11];
            });
        }
        else if (selector == 4)//diamond10
        {
            StorageHolders[0].onClick.AddListener(() =>
            {
                buttonItemSelector = 0;
                for (int i = 0; i < GameManager.IDs.Length; i++)
                {
                    if (GameManager.IDs[i] == 11)
                    {
                        myID = 11;
                    }
                }

                if (myID == 11)
                {
                    itemInfo.text = "Emerald earrings - 50.99";
                    itemHolder.sprite = items[10];
                    GameManager.itemID = 11;
                }
                else
                {
                    itemInfo.text = "Not Available";
                    itemHolder.sprite = items[11];
                }
            });
            StorageHolders[1].onClick.AddListener(() =>
            {
                buttonItemSelector = 1;
                itemInfo.text = "Not Available";
                itemHolder.sprite = items[11];
            });
            StorageHolders[2].onClick.AddListener(() =>
            {
                buttonItemSelector = 2;
                itemInfo.text = "Not Available";
                itemHolder.sprite = items[11];
            });
            StorageHolders[3].onClick.AddListener(() =>
            {
                buttonItemSelector = 3;
                itemInfo.text = "Not Available";
                itemHolder.sprite = items[11];
            });
            StorageHolders[4].onClick.AddListener(() =>
            {
                buttonItemSelector = 4;
                itemInfo.text = "Not Available";
                itemHolder.sprite = items[11];
            });
        }
    }

    private void AssignButtons()
    {
        StorageHolders.Clear();
        var rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (var rootObject in rootObjects)
        {
            Button[] buttons = rootObject.GetComponentsInChildren<Button>(true);
            foreach (Button btn in buttons)
            {
                if (btn.CompareTag("items")) // Asegúrate de que los botones tengan esta etiqueta
                {
                    StorageHolders.Add(btn);
                }
            }
        }
    }

    private void Update()
    {
        

        hat.onClick.AddListener(() =>
        {
            selector = 1;
            var myID = 0;
            var myID2 = 0;
            var myID3 = 0;
            var myID4 = 0;
            var myID5 = 0;

            for (int i = 0; i < GameManager.IDs.Length; i++)
            {
                if (GameManager.IDs[i] == 1)
                {
                    myID = 1;
                }
                else if (GameManager.IDs[i] == 2)
                {
                    myID2 = 2;
                }
                else if (GameManager.IDs[i] == 3)
                {
                    myID3 = 3;
                }
                else if (GameManager.IDs[i] == 4)
                {
                    myID4 = 4;
                }
                else if (GameManager.IDs[i] == 5)
                {
                    myID5 = 5;
                }
            }

            var item = StorageHolders[0].GetComponent<UnityEngine.UI.Image>();

            if (myID == 1)
            {

                item.sprite = hats[0];
            }
            else
            {
                item.sprite = items[11];
            }

            item = StorageHolders[1].GetComponent<UnityEngine.UI.Image>();

            if (myID2 == 2)
            {

                item.sprite = hats[1];
            }
            else
            {
                item.sprite = items[11];
            }

            item = StorageHolders[2].GetComponent<UnityEngine.UI.Image>();

            if (myID3 == 3)
            {

                item.sprite = hats[2];
            }
            else
            {
                item.sprite = items[11];
            }

            item = StorageHolders[3].GetComponent<UnityEngine.UI.Image>();

            if (myID4 == 4)
            {

                item.sprite = hats[3];
            }
            else
            {
                item.sprite = items[11];
            }

            item = StorageHolders[4].GetComponent<UnityEngine.UI.Image>();

            if (myID5 == 5)
            {

                item.sprite = hats[4];
            }
            else
            {
                item.sprite = items[11];
            }


            SetInventory();
        });

        shirt.onClick.AddListener(() =>
        {
            selector = 2;
            var myID = 0;
            var myID2 = 0;
            var myID3 = 0;

            for (int i = 0; i < GameManager.IDs.Length; i++)
            {
                if (GameManager.IDs[i] == 6)
                {
                    myID = 6;
                }
                else if (GameManager.IDs[i] == 7)
                {
                    myID2 = 7;
                }
                else if (GameManager.IDs[i] == 8)
                {
                    myID3 = 8;
                }
            }

            var item = StorageHolders[0].GetComponent<UnityEngine.UI.Image>();

            if (myID == 6)
            {

                item.sprite = shirts[0];
            }
            else
            {
                item.sprite = items[11];
            }

            item = StorageHolders[1].GetComponent<UnityEngine.UI.Image>();

            if (myID2 == 7)
            {

                item.sprite = shirts[1];
            }
            else
            {
                item.sprite = items[11];
            }

            item = StorageHolders[2].GetComponent<UnityEngine.UI.Image>();

            if (myID3 == 8)
            {

                item.sprite = shirts[2];
            }
            else
            {
                item.sprite = items[11];
            }

            item = StorageHolders[3].GetComponent<UnityEngine.UI.Image>();
            item.sprite = items[11];

            item = StorageHolders[4].GetComponent<UnityEngine.UI.Image>();
            item.sprite = items[11];

            SetInventory();
        });

        pant.onClick.AddListener(() =>
        {
            selector = 3;

            var myID = 0;
            var myID2 = 0;

            for (int i = 0; i < GameManager.IDs.Length; i++)
            {
                if (GameManager.IDs[i] == 9)
                {
                    myID = 9;
                }
                else if (i == 10)
                {
                    myID2 = 10;
                }
            }

            var item = StorageHolders[0].GetComponent<UnityEngine.UI.Image>();

            if (myID == 9)
            {

                item.sprite = pants[0];
            }
            else
            {
                item.sprite = items[11];
            }

            item = StorageHolders[1].GetComponent<UnityEngine.UI.Image>();

            if (myID2 == 10)
            {

                item.sprite = pants[1];
            }
            else
            {
                item.sprite = items[11];
            }


            item = StorageHolders[2].GetComponent<UnityEngine.UI.Image>();
            item.sprite = items[11];

            item = StorageHolders[3].GetComponent<UnityEngine.UI.Image>();
            item.sprite = items[11];

            item = StorageHolders[4].GetComponent<UnityEngine.UI.Image>();
            item.sprite = items[11];

            SetInventory();
        });

        jewl.onClick.AddListener(() =>
        {
            selector = 4;
            var myID = 0;

            for (int i = 0; i < GameManager.IDs.Length; i++)
            {
                if (GameManager.IDs[i] == 11)
                {
                    myID = 11;
                }
            }

            var item = StorageHolders[0].GetComponent<UnityEngine.UI.Image>();

            if (myID == 11)
            {

                item.sprite = jewls[0];
            }
            else
            {
                item.sprite = items[11];
            }


            item = StorageHolders[1].GetComponent<UnityEngine.UI.Image>();
            item.sprite = items[11];

            item = StorageHolders[2].GetComponent<UnityEngine.UI.Image>();
            item.sprite = items[11];

            item = StorageHolders[3].GetComponent<UnityEngine.UI.Image>();
            item.sprite = items[11];

            item = StorageHolders[4].GetComponent<UnityEngine.UI.Image>();
            item.sprite = items[11];

            SetInventory();
        });
    }

    void BuyMyItem()
    {
        if(GameManager.itemsBought < GameManager.maxInventoryItems)
        {
            for (int i = 0; i < GameManager.IDs.Length; i++)
            {
                if (GameManager.IDs[i] == GameManager.itemID)
                {
                    GameManager.IDs[i] = 0;
                    PlayerController.didBuy = true;
                    Debug.Log("compre");
                    var item = StorageHolders[buttonItemSelector].GetComponent<UnityEngine.UI.Image>();
                    item.sprite = items[11];
                    GameManager.itemsBought++;
                }
            }
        }
        else
        {
            keeperVoice.text = "I don't think you have any space left...";
        }
    }
}
