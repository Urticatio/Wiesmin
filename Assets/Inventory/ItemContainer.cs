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
}
