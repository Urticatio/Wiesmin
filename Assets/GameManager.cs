using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
        ItemSpawnManager.instance = itemSpawnManager;
        signPanel.SetActive(false);
    }

    public GameObject player;
    public ItemContainer inventoryContainer;
    public ItemContainer shopContainer;
    public DragAndDropController dragAndDropController;
    public ShopController shopController;
    public ItemSpawnManager itemSpawnManager;
    public BarController barController;
    public GameObject toolbarPanel;
    public GameObject inventoryPanel;
    public GameObject signPanel;
    public Bar staminaBar;
    public Bar healthBar;
    public int money;
    public Text priceTextField; //pole tekstowe ceny
    public DayTimeController timeController;
}
