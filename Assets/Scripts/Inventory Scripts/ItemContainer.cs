﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
//klasa do przechowywania referencji do itemka przechowywanego w kontenerze
public class ItemSlot
{
    public Item item;
    public int count; //ile jest przedmiotów
    public ItemContainer container; //w krótym kontenerze jest (ekwipunek, sklep)

    public void Copy(ItemSlot slot) //kopiowanie z innego slota
    {
        item = slot.item;
        count = slot.count;
        container = slot.container;
    }

    public void Set(Item item, int count, ItemContainer container)
    {
        this.item = item;
        this.count = count;
        this.container = container;
    }
    public void Clear()
    {
        item = null;
        count = 0;
    }
}

[CreateAssetMenu(menuName = "Data/Item Container")]

public class ItemContainer : ScriptableObject
{
    public List<ItemSlot> slots; //tu przechowywane są itemki

    public void Add(Item item, int count, ItemContainer itemContainer)//metoda do dodawania itemków do ekwipunku
    {
        if(item.stackable == true) //jeśli da się stackować
        {
            ItemSlot itemSlot = slots.Find(x => x.item == item);//szuka, czy jest już taki obiekt w ekwipunku
            if (itemSlot != null)//jeśli jest taki obiekt
            {
                itemSlot.count += count; //dodaje odpowiednią ilość (przekazaną w funkcji)
            }
            else //jeśli nie ma jeszcze takiego obiektu
            {
                itemSlot = slots.Find(x => x.item == null);//szuka slota, w którym nie ma itemka
                if (itemSlot != null)//jeśli jest jakieś puste miejsce
                {
                    itemSlot.item = item;
                    itemSlot.count = count;
                    itemSlot.container = itemContainer;
                }
            }

        }
        else //jeśli nie da się stackować
        {
            ItemSlot itemSlot = slots.Find(x => x.item == null);//szuka slota, w którym nie ma itemka
            if (itemSlot != null)//jeśli jest jakieś puste miejsce
            {
                itemSlot.item = item;
                itemSlot.count = count;
            }
        }
        //"odświeżenie" toolbara
        GameManager.instance.toolbarPanel.SetActive(false);
        GameManager.instance.toolbarPanel.SetActive(true);
    }
    
    public void Remove(ItemSlot itemSlot)//metoda do usuwania itemków z ekwipunku
    {
        if (itemSlot.item.stackable == true) //jeśli da się stackować
        {
            itemSlot.count--;//usuwa jedną sztukę
            if (itemSlot.count == 0) itemSlot.Clear(); //jeśli usunął ostatnią sztukę
        }
        else //jeśli nie da się stackować
        {
            itemSlot.Clear();
        }
        //"odświeżenie" toolbara
        GameManager.instance.toolbarPanel.SetActive(false);
        GameManager.instance.toolbarPanel.SetActive(true);
    }
    
    public void Remove(Item itemToRemove, int count = 1)//metoda do usuwania itemków z ekwipunku - ver Magdy
    {
        if (itemToRemove.stackable) //jeśli da się stackować
        {
            ItemSlot itemSlot = slots.Find(x => x.item == itemToRemove);
            if (itemSlot == null) { return; }

            itemSlot.count -= count;
            if (itemSlot.count <= 0) itemSlot.Clear(); //jeśli usunął ostatnią sztukę
        }
        else
        {
            while(count > 0)
            {
                count -= 1;
                ItemSlot itemSlot = slots.Find(x => x.item == itemToRemove);
                if (itemSlot == null) { return; }

                itemSlot.Clear();
            }
        }
        GameManager.instance.toolbarPanel.SetActive(false);
        GameManager.instance.toolbarPanel.SetActive(true);
    }

    public int Count(string name)
    {
        ItemSlot itemSlot = slots.Find(x => x.item.name == name);
        return itemSlot.count;
    }

}
