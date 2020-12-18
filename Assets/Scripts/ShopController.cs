using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] GameObject shopPanel;
    [SerializeField] ItemSlot itemSlot; //"przechowywany" item -- sprzedawany lub kupowany
    

    private void Start()
    {
        itemSlot = new ItemSlot();
    }

    private void Update()
    {
       
    }

    internal void OnClick(ItemSlot itemSlot, ItemContainer container)//przyjmuje "kliknięty" item i ekwipunek z którego pochodzi
    {
        ItemContainer shop = GameManager.instance.shopContainer;
        ItemContainer inventory = GameManager.instance.inventoryContainer;
        int money = GameManager.instance.money;
        if (shopPanel.activeInHierarchy && container==shop)//jeśli sklep jest otwarty i item kliknięty jest w panelu sklepu
        {
            //zakup
            
            if((money-itemSlot.item.price) >= 0)//jeśli starcza nam pieniędzy
            {
                money -= itemSlot.item.price;
                inventory.Add(itemSlot.item, 1, inventory);//dodaje do ekwipunku przedmiot
                UpdateInventoryAndMoney();
            }
            else
            {
                //MessageBox.Show();
            }

            
        }
        else if (shopPanel.activeInHierarchy && container == inventory)//jeśli sklep jest otwarty i item kliknięty jest w panelu ekwipunku
        {
            //sprzedaż
            money += itemSlot.item.price;
            inventory.Remove(itemSlot);
            UpdateInventoryAndMoney();
        }

    }

    private void UpdateInventoryAndMoney()
    {
        GameManager.instance.inventoryPanel.SetActive(false);
        GameManager.instance.inventoryPanel.SetActive(true);
        GameManager.instance.toolbarPanel.SetActive(false); //wyłącza toolbar
    }
}
