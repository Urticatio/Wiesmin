using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Item")] //żeby móc utworzyć instancję ScriptableObject

public class Item : ScriptableObject
{
    public string Name;
    public bool stackable;
    public Sprite icon;
    public int price;
}
