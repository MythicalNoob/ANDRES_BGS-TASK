using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject textBox;
    public GameObject storeInventory;
    public GameObject buttons;
    public Button buy;
    public Button sell;
    public Button close;
    public Button closeConfirm;
    public Button sellConfirm;
    public TextMeshProUGUI keepersvoice;
    
    public static int itemID = 0;
    public static int maxInventoryItems = 9;
    public static int itemsBought = 0;
    public static bool didSell = false;

    [HideInInspector]
    public static int[] IDs = new int[11] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

    int myitems = 0;

    void Start()
    {
        textBox.SetActive(false);
        storeInventory.SetActive(false);
        sellConfirm.gameObject.SetActive(false);

        buy.onClick.AddListener(() => {
            keepersvoice.text = "What do you want to buy?";
            storeInventory.SetActive(true);
            buttons.SetActive(false);
        });



        sell.onClick.AddListener(() => {

            if (myitems <= 0)
            {
                keepersvoice.text = "You don't have anything on you..";
            }
            else if (myitems > 0)
            {
                keepersvoice.text = "What do you want to sell?";
                didSell = true;
                sellConfirm.gameObject.SetActive(true);
                closeConfirm.gameObject.SetActive(true);
                buttons.SetActive(false);
            }

        });

        close.onClick.AddListener(() => {
            sell.gameObject.SetActive(true);
            buy.gameObject.SetActive(true);
            storeInventory.SetActive(false);
            textBox.SetActive(false);
        });

    }

    private void Update()
    {
        myitems = itemsBought;
    }

    public void StoreKeeper()
    {
        textBox.SetActive(true);
    }

}
