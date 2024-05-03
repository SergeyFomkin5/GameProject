using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string ItemName;
    [SerializeField] private int Quantity;
    [SerializeField] private Sprite sprite;
    [SerializeField] private string ItemDescription;
    [TextArea] 

    private InventoryManager inventoryManager;
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inventoryManager.AddItem(ItemName, Quantity, sprite, ItemDescription);
            Destroy(gameObject);
        }
    }
}
