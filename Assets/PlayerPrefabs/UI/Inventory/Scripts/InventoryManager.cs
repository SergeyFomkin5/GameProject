using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool MenuActive;
    public ItemSlot[] itemSlot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && MenuActive)
        {
            InventoryMenu.SetActive(false);
            MenuActive = false;
            Time.timeScale = 1.0f;
        }
        else if (Input.GetKeyDown(KeyCode.I) && !MenuActive)
        {
            InventoryMenu.SetActive(true);
            MenuActive = true;
            Time.timeScale = 0f;
        }
    }

    public void AddItem(string ItemName, int Quantity, Sprite sprite)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(ItemName, Quantity, sprite);
                return;
            }
        }
    }
}
