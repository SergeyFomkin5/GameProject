﻿using System.Collections;
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

    public  void AddItem(string ItemName, int Quantity, Sprite sprite, string ItemDescription)
    {
        this.ItemName = ItemName;
        this.Quantity = Quantity;
        this.sprite = sprite;
        this.ItemDescription = ItemDescription;
        isFull = true;

        QuantityText.text = Quantity.ToString();
        QuantityText.enabled = true;
        ItemImage.sprite = sprite;
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

    }

    public void OnLeftClick()
    {
        inventoryManager.DeselectAllSlots();
        SelectedShader.SetActive(true);
        ThisItemSelected = true;
        ItemDescriptionNameText.text = ItemName;
        ItemDescriptionText.text = ItemDescription;
        ItemDescriptionImage.sprite = sprite;
    }
}
