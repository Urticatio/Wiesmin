using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/ToolAction/Water")]
public class TileWateringAction : ToolAction
{
    public override bool OnApplyToTileMap(Vector3Int gridPosition, TileMapReadController tileMapReadController, Item item)
    {
        tileMapReadController.cropsManager.Water(gridPosition);
        //zmien wyglad TODO
        return true;
    }
}
