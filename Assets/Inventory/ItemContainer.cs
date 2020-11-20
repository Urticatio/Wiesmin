using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
//klasa do przechowywania referencji do itemka przechowywanego w kontenerze
public class ItemSlot
{
    public Item item;
    public int count; //ile jest przedmiotów
}

[CreateAssetMenu(menuName = "Data/Item Container")]
public class ItemContainer : ScriptableObject
{
    public List<ItemSlot> slots; //tu przechowywane są itemki

    public void Add(Item item, int count = 1)//metoda do dodawania itemków do ekwipunku
    {
        if(item.stackable == true) //jeśli da się stackować
        {
            ItemSlot itemSlot = slots.Find(x => x.item == item);//szuka, czy jest już taki obiekt w ekwipunku
            if (itemSlot != null)//jeśli jest taki obiekt
            {
                itemSlot.count += count; //dodaje odpowiednią ilość (przekazaną w funkcji)
            }
            else
            {
                itemSlot = slots.Find(x => x.item == null);//szuka slota, w którym nie ma itemka
                if (itemSlot != null)//jeśli jest jakieś puste miejsce
                {
                    itemSlot.item = item;
                    itemSlot.count = count;
                }
            }

        }
        else //jeśli nie da się stackować
        {
            ItemSlot itemSlot = slots.Find(x => x.item == null);//szuka slota, w którym nie ma itemka
            if (itemSlot != null)//jeśli jest jakieś puste miejsce
            {
                itemSlot.item = item;
            }
        }
    }
}
