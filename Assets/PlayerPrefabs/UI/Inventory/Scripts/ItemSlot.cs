using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //======Item Data=======//
    public string ItemName;
    public int Quantity;
    public Sprite sprite;
    public bool isFull;

    //======Item Slot======//
    [SerializeField] private TMP_Text QuantityText;
    [SerializeField] private Image ItemImage;

    public  void AddItem(string ItemName, int Quantity, Sprite sprite)
    {
        this.ItemName = ItemName;
        this.Quantity = Quantity;
        this.sprite = sprite;
        isFull = true;

        QuantityText.text = Quantity.ToString();
        QuantityText.enabled = true;
        ItemImage.sprite = sprite;
    }
}
