using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
        ItemSpawnManager.instance = itemSpawnManager;
        signPanel.SetActive(false);     
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public GameObject player;
    public GameObject monster;
    public ItemContainer inventoryContainer;
    public ItemContainer shopContainer;
    public DragAndDropController dragAndDropController;
    public ShopController shopController;
    public FableController fableController;
    public EventController eventController;
    public DayTimeController dayTimeController;
    public ItemSpawnManager itemSpawnManager;
    public BarController barController;
    public GameObject toolbarPanel;
    public GameObject inventoryPanel;
    public GameObject signPanel;
    public Bar staminaBar;
    public Bar healthBar;
    public int money;
    public Text priceTextField; //pole tekstowe ceny
    public Text moneyTextField;
    public DayTimeController timeController;
}
