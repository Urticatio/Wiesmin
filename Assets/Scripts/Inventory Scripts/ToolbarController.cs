﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolbarController : MonoBehaviour
{
    [SerializeField] int toolbarSize = 6;
    int selectedTool;
    public Action<int> onChange; //delegate
    public Item GetItem
    {
        get{
            return GameManager.instance.inventoryContainer.slots[selectedTool].item;
        }
    }
    private void Update()
    {
        float delta = Input.mouseScrollDelta.y;
        if(delta != 0) //gdy scrollujemy
        {
            if(delta < 0)
            {
                selectedTool += 1;
                selectedTool = (selectedTool >= toolbarSize ? 0 : selectedTool);
            }
            else
            {
                selectedTool -= 1;
                selectedTool = (selectedTool < 0 ? toolbarSize-1 : selectedTool);
            }
            onChange?.Invoke(selectedTool);
        }
    }
    internal void Set(int id)
    {
        selectedTool = id;
    }
}
