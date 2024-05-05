using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //======Item Data=======//
    public string ItemName;
    public int Quantity;
    public Sprite sprite;
    public bool isFull;
    public string ItemDescription;
    public Sprite EmptySprite;
    [SerializeField] private int maxNumberOfItems;

    //======Item Slot======//
    [SerializeField] private TMP_Text QuantityText;
    [SerializeField] private Image ItemImage;

    //======Item Description Slot======//
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;

    public GameObject SelectedShader;
    public bool ThisItemSelected;

    private InventoryManager inventoryManager;



    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public int AddItem(string ItemName, int Quantity, Sprite sprite, string ItemDescription)
    {
        //Check to see if the slot is akready full
        if (isFull)

            return Quantity;


        this.ItemName = ItemName;
        this.sprite = sprite;
        ItemImage.sprite = sprite;
        this.ItemDescription = ItemDescription;
        this.Quantity += Quantity;
        if (this.Quantity >= maxNumberOfItems)
        {
            QuantityText.text = maxNumberOfItems.ToString();
            QuantityText.enabled = true;
            isFull = true;

            int extraItems = this.Quantity - maxNumberOfItems;
            this.Quantity = maxNumberOfItems;
            return extraItems;
        }

        QuantityText.text = this.Quantity.ToString();
        QuantityText.enabled = true;

        return 0;


    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }



    public void OnRightClick()
    {
        if (Quantity > 0)
        {
            GameObject itemToDrop = new GameObject(ItemName);
            Item newItem = itemToDrop.AddComponent<Item>();
            newItem.Quantity = 1;
            newItem.ItemName = ItemName;
            newItem.sprite = sprite;
            newItem.ItemDescription = ItemDescription;


            SpriteRenderer sr = itemToDrop.AddComponent<SpriteRenderer>();
            sr.sprite = sprite;
            sr.sortingOrder = 5;
            sr.sortingLayerName = "Ground";

            itemToDrop.AddComponent<BoxCollider>();

            itemToDrop.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(1, 0f, 0f);
            itemToDrop.transform.localScale = new Vector3(.5f, .5f, .5f);

            this.Quantity -= 1;
            QuantityText.text = this.Quantity.ToString();
            if (this.Quantity <= 0)
            {
                EmptySlot();
            }

        }

    }

    public void OnLeftClick()
    {
        if (ThisItemSelected)
        {
            QuantityText.text = this.Quantity.ToString();
            Quantity -= 1;
            if (this.Quantity <= 0)
            {
                EmptySlot();
                
            }
        }
        

        else
        {
            inventoryManager.DeselectAllSlots();
            SelectedShader.SetActive(true);
            ThisItemSelected = true;
            ItemDescriptionNameText.text = ItemName;
            ItemDescriptionText.text = ItemDescription;
            ItemDescriptionImage.sprite = sprite;

            if (ItemDescriptionImage.sprite == null)
            {
                ItemDescriptionImage.sprite = EmptySprite;
            }
        }
            
        
    }

        
    

    private void EmptySlot()
    {
        QuantityText.enabled = false;

        ItemImage.sprite = EmptySprite;

        ItemDescriptionNameText.text = "";
        ItemDescriptionText.text = "";
        ItemDescriptionImage.sprite = EmptySprite;
        
        
    }
}
