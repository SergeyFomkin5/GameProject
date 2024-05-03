using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool MenuActive;
    public ItemSlot[] itemSlot;
    public GameObject Player;
    PlayerController playerController;
    public GameObject gancontroller;
    float zero = 0f;

    void Start()
    {
        playerController = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.I) && MenuActive) && Time.time > zero)
        {
            zero = Time.time + .2f;
            gancontroller.SetActive(false);
            playerController.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
            InventoryMenu.SetActive(true);
            MenuActive = false;
            
        }
        else if (Input.GetKeyDown(KeyCode.I) && !MenuActive)
        {
            
            gancontroller.SetActive(true);
            playerController.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1.0f;
            InventoryMenu.SetActive(false);
            MenuActive = true;
        }
    }

    public void AddItem(string ItemName, int Quantity, Sprite sprite, string ItemDescripion)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(ItemName, Quantity, sprite, ItemDescripion);
                return;
            }
        }
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].SelectedShader.SetActive(false);
            itemSlot[i].ThisItemSelected = false;
        }
    }
}
