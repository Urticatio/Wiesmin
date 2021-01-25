using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
//using UnityEditor.Tilemaps;

public class ToolsCharacterController : MonoBehaviour
{
    CharacterController2D character;
    Rigidbody2D rgdb2d;
    ToolbarController toolbarController;
    Animator animator;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TileMapReadController tileMapReadController;
    [SerializeField] float maxDistance = 1.5f;
    [SerializeField] ToolAction onTilePickUp;
    [SerializeField] ToolAction onTileWatering;

    Vector3Int selectedTilePosition;
    bool selectable;
    private void Awake()
    {
        rgdb2d = GetComponent<Rigidbody2D>();
        character = GetComponent<CharacterController2D>();
        toolbarController = GetComponent<ToolbarController>();
        animator = GetComponent<Animator>();
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
        Item item = toolbarController.GetItem;
        if(item == null) { return false; }
        if (item.onAction == null) { return false; }

        animator.SetTrigger("attacking");
        bool complete = item.onAction.OnApply(position);
        if (complete)
        {
            if (item.onItemUsed != null)
            {
                item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
            }
        }

        return complete;
    }
    private void UseToolGrid()// interact with tiles
    {
        if(selectable == true)
        {
            Item item = toolbarController.GetItem;
            //if (item == null)
            {
                PickUpTile();
                //return;
            }
            if (item.onTileMapAction == null) { return; }

            //animator.SetTrigger("act");
            bool complete = item.onTileMapAction.OnApplyToTileMap(selectedTilePosition, tileMapReadController, item);

            if(complete)
            {
                if(item.onItemUsed != null)
                {
                    item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
                }
            }
        }
    }
    private void PickUpTile()
    {
        if (onTilePickUp == null) { return; }
        onTilePickUp.OnApplyToTileMap(selectedTilePosition, tileMapReadController, null);
    }
    private void WaterTile()
    {
        if (onTileWatering == null) { return; }
        onTileWatering.OnApplyToTileMap(selectedTilePosition, tileMapReadController, null);
    }
}
