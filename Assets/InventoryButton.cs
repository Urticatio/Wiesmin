﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Text text;

    int myIndex;
    public void SetIndex(int index)
    {
        myIndex = index;
    }

    public void Set(ItemSlot slot) //ustawia item, który znajduje się w miejscu tego przycisku
    {
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon; //ustawia obrazek tego co przechowuje
        if (slot.item.stackable == true)
        {
            text.gameObject.SetActive(true);
            text.text = slot.count.ToString();
        }
        else
        {
            text.gameObject.SetActive(false);
        }
    }

    public void Clean()//gdy usuwamy item z przycisku
    {
        icon.sprite = null;
        icon.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }
}