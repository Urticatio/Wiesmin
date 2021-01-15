using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor.Tilemaps;

public class CropTile//current state of crop
{
    public Crop crop;//type of crop
    public int growTimer;
    public int growStage;
    public SpriteRenderer renderer;
    public bool watered;
    public bool Complete
    {
        get
        {
            if (crop == null) { return false; }
            return growTimer >= crop.timeToGrow;
        }
    }
    internal void Harvested()
    {
        growTimer = 0;
        growStage = 0;
        crop = null;
        renderer.gameObject.SetActive(false);
    }
}
public class CropsManager : TimeAgent
{
    [SerializeField] TileBase seeded;
    [SerializeField] TileBase plowed;
    [SerializeField] TileBase watered;
    //[SerializeField] TileBase growing;//
    //[SerializeField] TileBase grown;//
    [SerializeField] Tilemap targetTilemap;
    [SerializeField] Tilemap waterTilemap;
    [SerializeField] GameObject cropsSpritePrefab;
    public float scattering_level;
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
            if (cropTile.crop == null) { continue; }

            if (cropTile.Complete)
            {
                Debug.Log("im done growing");
                continue;
            }
            if(cropTile.watered)
                cropTile.growTimer += 1;

            waterTilemap.ClearAllTiles();
            cropTile.watered = false;

            if (cropTile.growTimer >= cropTile.crop.growStageTime[cropTile.growStage])
            {
                cropTile.renderer.gameObject.SetActive(true);
                cropTile.renderer.sprite = cropTile.crop.sprites[cropTile.growStage];

                cropTile.growStage += 1;
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
        CropTile crop = new CropTile();
        crops.Add((Vector2Int)position, crop);

        GameObject go = Instantiate(cropsSpritePrefab);
        go.transform.position = targetTilemap.CellToWorld(position);
        go.SetActive(false);
        crop.renderer = go.GetComponent<SpriteRenderer>();

        targetTilemap.SetTile(position, plowed);
    }
    private void CreateWetTile(Vector3Int position)
    {
        waterTilemap.SetTile(position, watered);
    }
    internal void PickUp(Vector3Int gridPosition)
    {
        Vector2Int position = (Vector2Int)gridPosition;
        if (crops.ContainsKey(position) == false) { return; }

        CropTile cropTile = crops[position];

        if (cropTile.Complete)
        {
            int dropCount = cropTile.crop.dropCount;
            while (dropCount > 0)
            {
                dropCount -= 1;
                Vector3Int position2 = gridPosition;
                position2.x += (int)(scattering_level * UnityEngine.Random.value - scattering_level / 2);
                position2.y += (int)(scattering_level * UnityEngine.Random.value - scattering_level / 2);

                ItemSpawnManager.instance.SpawnItem(targetTilemap.CellToWorld(position2), cropTile.crop.yield, cropTile.crop.count, true);
            }
            
            

            targetTilemap.SetTile(gridPosition, plowed);
            cropTile.Harvested();
        }
    }
    public void Water(Vector3Int gridPosition)
    {
        Vector2Int position = (Vector2Int)gridPosition;
        if (crops.ContainsKey(position) == false) { return; }

        CropTile cropTile = crops[position];
        cropTile.watered = true;
        GameManager.instance.staminaBar.Subtract(3); //zużywa wytrzymałość
        CreateWetTile(gridPosition);
    }
    /*
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
    */
}
