using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor.Tilemaps;

public class Crops
{

}
public class CropsManager : MonoBehaviour
{
    [SerializeField] TileBase seeded;
    [SerializeField] TileBase plowed;
    [SerializeField] TileBase growing;
    [SerializeField] TileBase grown;
    [SerializeField] Tilemap targetTilemap;

    Dictionary<Vector2Int, Crops> crops;

    private void Start()
    {
        crops = new Dictionary<Vector2Int, Crops>();
    }

    public bool Check(Vector3Int position)
    {
        return crops.ContainsKey((Vector2Int)position);
    }
    public void Plow(Vector3Int position)
    {
        if(crops.ContainsKey((Vector2Int)position))
        {
            return;
        }

        CreatePlowedTile(position);
    }
    public void Seed(Vector3Int position)
    {
        targetTilemap.SetTile(position, seeded);

    }
    private void CreatePlowedTile(Vector3Int position)
    {
        Crops crop = new Crops();
        crops.Add((Vector2Int)position, crop);

        targetTilemap.SetTile(position, plowed);
    }
    public void Grow(Vector3Int position)
    {
        TileBase s = (TileBase)targetTilemap.GetTile(position);
        if(s == seeded)
        targetTilemap.SetTile(position, growing);

        if (s == grown)
            targetTilemap.SetTile(position, grown);

    }
    public void GrowToMaturePlant(Vector3Int position)
    {
        TileBase s = (TileBase)targetTilemap.GetTile(position);
        if (s == grown)
            targetTilemap.SetTile(position, grown);

    }
}
