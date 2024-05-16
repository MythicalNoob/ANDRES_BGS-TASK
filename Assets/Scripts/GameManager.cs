using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject textBox;
    public GameObject storeInventory;
    public Button buy;
    public Button sell;
    public Button close;
    
    void Start()
    {
        textBox.SetActive(false);
        storeInventory.SetActive(false);

        buy.onClick.AddListener(() => { 
            storeInventory.SetActive(true); 
        }) ;

        close.onClick.AddListener(() => {
            storeInventory.SetActive(false);
            textBox.SetActive(false);
        });
    }

    public void StoreKeeper()
    {
        textBox.SetActive(true);
    }

}
