using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor.Tilemaps;

public class CropTile//current state of crop
{
    public Crop crop;//type of crop
    public int growTimer;
}
public class CropsManager : TimeAgent
{
    [SerializeField] TileBase seeded;
    [SerializeField] TileBase plowed;
    [SerializeField] TileBase growing;//
    [SerializeField] TileBase grown;//
    [SerializeField] Tilemap targetTilemap;

    Dictionary<Vector2Int, CropTile> crops;

    private void Start()
    {
        crops = new Dictionary<Vector2Int, CropTile>();
        onTimeTick += Tick;
        Init();
    }

    public void Tick()
    {
        foreach (CropTile cropTile in crops.Values)
        {
            if (cropTile == null) { continue; }

            cropTile.growTimer += 1;//TODO check if watered

            if(cropTile.growTimer >= cropTile.crop.timeToGrow)
            {
                Debug.Log("im done growing");
                cropTile.crop = null;
            }
        }
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
        GameManager.instance.staminaBar.Subtract(3); //zużywa wytrzymałość
        CreatePlowedTile(position);
    }
    public void Seed(Vector3Int position, Crop toSeed)
    {
        targetTilemap.SetTile(position, seeded);
        crops[(Vector2Int)position].crop = toSeed;
        GameManager.instance.staminaBar.Subtract(3); //zużywa wytrzymałość
    }
    private void CreatePlowedTile(Vector3Int position)
    {
        //CropTile crop = new CropTile();
        //crops.Add((Vector2Int)position, crop);

        targetTilemap.SetTile(position, plowed);
    }
    public void Grow(Vector3Int position)
    {
        TileBase s = (TileBase)targetTilemap.GetTile(position);
        if(s == seeded)
        targetTilemap.SetTile(position, growing);

        if (s == grown)
            targetTilemap.SetTile(position, grown);
        GameManager.instance.staminaBar.Subtract(3); //zużywa wytrzymałość
    }
    public void GrowToMaturePlant(Vector3Int position)
    {
        TileBase s = (TileBase)targetTilemap.GetTile(position);
        if (s == grown)
            targetTilemap.SetTile(position, grown);

    }
}
