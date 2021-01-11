using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolAction : ScriptableObject
{
    public virtual bool OnApply(Vector2 worldPoint)
    {
        Debug.LogWarning("OnApplay is KeyNotFoundException impremented");
        return true;
    }
    public virtual bool OnApplyToTileMap(Vector3Int gridPosition, TileMapReadController tileMapReadController)
    {
        Debug.LogWarning("OnApplyToTileMap is KeyNotFoundException impremented");
        return true;
    }
    public virtual void OnItemUsed(Item usedItem, ItemContainer inventory)
    {
    }
}
