using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
        ItemSpawnManager.instance = itemSpawnManager;
    }

    public GameObject player;
    public ItemContainer inventoryContainer;
    public ItemContainer shopContainer;
    public DragAndDropController dragAndDropController;
    public ShopController shopController;
    public ItemSpawnManager itemSpawnManager;
    public GameObject toolbarPanel;
    public GameObject inventoryPanel;
    public int money;
}
