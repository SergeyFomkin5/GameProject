using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public string ItemName;
    [SerializeField] public int Quantity;
    [SerializeField] public Sprite sprite;
    [SerializeField] public string ItemDescription;
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
            int leftOverItems = inventoryManager.AddItem(ItemName, Quantity, sprite, ItemDescription);
            if (leftOverItems <= 0)
                Destroy(gameObject);
            
            else
                Quantity = leftOverItems;
            
            
        }
    }
}
