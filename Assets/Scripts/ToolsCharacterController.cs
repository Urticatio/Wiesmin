using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor.Tilemaps;

public class ToolsCharacterController : MonoBehaviour
{
    CharacterController2D character;
    Rigidbody2D rgdb2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TileMapReadController tileMapReadController;
    [SerializeField] float maxDistance = 1.5f;
    [SerializeField] CropsManager cropsManager;
    //[SerializeField] TileData plowableTiles;TODO

    Vector3Int selectedTilePosition;
    bool selectable;
    private void Awake()
    {
        rgdb2d = GetComponent<Rigidbody2D>();
        character = GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        SelectTile();
        CanSelectCheck();
        Marker();
        if (Input.GetMouseButtonDown(0))
        {
            if(UseToolWorld())
            {
                return;
            }
            UseToolGrid();
        }
    }
    private void SelectTile()
    {
        selectedTilePosition = tileMapReadController.GetGridPosition(Input.mousePosition, true);
    }
    void CanSelectCheck()
    {
        Vector2 characterPosiiton = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(characterPosiiton, cameraPosition) < maxDistance;
        markerManager.Show(selectable);
    }
    private void Marker()
    {
        markerManager.markedCellPosition = selectedTilePosition;
    }
    private bool UseToolWorld()//interact with objects (with colider2d)
    {
        Vector2 position = rgdb2d.position + character.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        return false;//TODO, fast fix
        foreach (Collider2D c in colliders)
        {
            
            /*
            ToolHit hit = c.GetComponent<ToolHit>();
            if (hit != null)
            {

                hit.Hit();
                return false;
            }
            */
        }
    }
    private void UseToolGrid()// interact with tiles
    {
        if(selectable)
        {
            //TileBase tileBase = tileMapReadController.GetTileBase(selectedTilePosition);
            //TileData tileData = tileMapReadController.GetTileData(tileBase);
            //if(tileData != plowableTiles) { return; }TODO
            if (cropsManager.Check(selectedTilePosition))
            {
                cropsManager.Seed(selectedTilePosition);
            }
            cropsManager.Plow(selectedTilePosition);
        }
    }
}
