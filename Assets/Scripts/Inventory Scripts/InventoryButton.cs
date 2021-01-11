using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler //kliknięcie wywołuje zdarzenie, podobnie najechanie i "odjechanie" myszy
{
    [SerializeField] Image icon;
    [SerializeField] Text text;
    [SerializeField] Image highlight;
    [SerializeField] ItemContainer container;
    

    int myIndex;
    private int price = 0; //cena przedmiotu na danym polu ekwipunku
    private Text priceText;
    public void Start()
    {
        priceText = GameManager.instance.priceTextField;
    }
    
    //ItemContainer inventoryContainer = GameManager.instance.inventoryContainer;


    public void SetIndex(int index)
    {
        myIndex = index;
    }

    public void Set(ItemSlot slot) //ustawia item, który znajduje się w miejscu tego przycisku
    {
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon; //ustawia obrazek tego co przechowuje
        price = slot.item.price;
        if (slot.item.stackable == true)
        {
            text.gameObject.SetActive(true);
            text.text = slot.count.ToString();
        }
        else
        {
            text.gameObject.SetActive(false);
        }
    }

    public void Clean()//gdy usuwamy item z przycisku
    {
        icon.sprite = null;
        icon.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)//wywoływana po kliknięciu na przycisk
    {
        ItemContainer inventory = GameManager.instance.inventoryContainer;
        ItemContainer shop = GameManager.instance.shopContainer;

        if (container == inventory)
        {
            //wywołuje metodę przeciągania
            ItemPanel itemPanel = transform.parent.GetComponent<ItemPanel>();
            itemPanel.OnClick(myIndex, inventory);

            //sprzedaży
            GameManager.instance.shopController.OnClick(inventory.slots[myIndex], inventory);
        }
        else if (container == shop)//wywołuje metodę kupowania
        {
            GameManager.instance.shopController.OnClick(shop.slots[myIndex], shop);
        }
        /*old version
        ItemContainer inventory = GameManager.instance.inventoryContainer;
        GameManager.instance.dragDropController.OnClick(inventory.slots[myIndex]);//wywołuje funkcję przekazując kliknięty przycisk
        transform.parent.GetComponent<InventoryPanel>().Show(); //odświeża ekwipunek
        */
    }
    public void OnPointerEnter(PointerEventData eventData)//gdy mysz najedzie na przycisk
    {
        priceText.gameObject.SetActive(true); //pokazuje pole z tekstem
        priceText.text = "Cena: " + price.ToString();
    }

    public void Highlight(bool b)//selecting items from toolbar
    {
        highlight.gameObject.SetActive(b);
    }

    
}
