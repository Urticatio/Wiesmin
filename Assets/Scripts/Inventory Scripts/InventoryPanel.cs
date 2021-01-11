using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryPanel : ItemPanel
{
    public override void OnClick(int id, ItemContainer container)
    {

        GameManager.instance.dragAndDropController.OnClick(inventory.slots[id], inventory);
        Show();
    }
}
// old version
/*
public class InventoryPanel : MonoBehaviour
{
    [SerializeField] ItemContainer inventory; //referencja do kontenera
    [SerializeField] List<InventoryButton> buttons; //referencja do przycisków
    public void Start()
    {
        SetIndex();
        Show();
    }

    private void OnEnable()//żeby się dobrze włączał ekwipunek
    {
        Show();
    }
    private void SetIndex()
    {
        for(int i=0; i < inventory.slots.Count && i < buttons.Count; i++)
        {
            buttons[i].SetIndex(i);
        }
    }

    public void Show() //pokazuje te sloty, w których coś jest
    {
        for(int i=0; i< inventory.slots.Count && i < buttons.Count; i++)
        {
            if(inventory.slots[i].item == null)//jeśli nic nie ma w tym polu, to je czyści
            {
                buttons[i].Clean();
            }
            else //jeśli coś jest w tym polu, to pokazuje
            {
                buttons[i].Set(inventory.slots[i]);
            }
        }
    }
}*/
