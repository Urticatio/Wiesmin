﻿using System.Collections;
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
    public DragAndDropController dragAndDropController;
    public ItemSpawnManager itemSpawnManager;
    public GameObject toolbarPanel;
}
