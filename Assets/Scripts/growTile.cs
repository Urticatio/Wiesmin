using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/ToolAction/GrowTile")]
public class growTile : ToolAction
{
    public override bool OnApplyToTileMap(Vector3Int gridPosition, TileMapReadController tileMapReadController, Item item)
    {
        if (tileMapReadController.cropsManager.Check(gridPosition) == false) { return false; }
        tileMapReadController.cropsManager.Grow(gridPosition);
        return true;
    }
    public override void OnItemUsed(Item usedItem, ItemContainer inventory)
    {
    //    inventory.Remove(usedItem);
    }
   
}
