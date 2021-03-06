﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//obsługuje klikanie (przeciąganie) przedmiotów w ekwipunku
public class DragAndDropController : MonoBehaviour
{
    [SerializeField] GameObject shopPanel;
    [SerializeField] ItemSlot itemSlot; //"przechowywany" item
    [SerializeField] GameObject dragItemIcon; //ikona przeciąganego itemka
    RectTransform iconTransform; //przechowuje pozycje itp. ikonki
    Image iconImage;
    ItemContainer container;

    private void Start()
    {
        itemSlot = new ItemSlot();
        iconTransform = dragItemIcon.GetComponent<RectTransform>();
        iconImage = dragItemIcon.GetComponent<Image>();
        container = GameManager.instance.inventoryContainer;
    }

    private void Update()
    {
        if(dragItemIcon.activeInHierarchy == true)//jeśli ikona przeciąganego obiektu jest widoczna
        {
            iconTransform.position = Input.mousePosition; //przypisuje pozycję myszy ikonce
            
            //wyrzucanie przedmiotu
            if (Input.GetMouseButtonDown(0))//jeśli lewy przycisk myszy jest wciśnięty
            {
                if (EventSystem.current.IsPointerOverGameObject() == false)//jeśli kursor nie jest nad aktualnym obiektem EventSystem
                {
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);//konwertuje pozycję myszy na pozycję na mapie
                    worldPosition.z = 0;//żeby się przypadkiem nie pojawiło za mapą 
                    Drop(itemSlot, worldPosition); //upuszcza przedmiot
                    dragItemIcon.SetActive(false);//chowa ikonę po upuszczeniu przedmiotu
                }
            }
            
        }
    }

    public void Drop(ItemSlot itemSl, Vector3 worldPosition)//upuszcza przedmiot
    {                 
        ItemSpawnManager.instance.SpawnItem(//upuszcza w tym miejscu przedmiot
            worldPosition,
            itemSl.item,
            itemSl.count,
            false);
        itemSl.Clear();//czyści pole po wyrzuceniu
    }

    internal void OnClick(ItemSlot itemSlot, ItemContainer inventoryContainer)//przyjmuje "kliknięty" item
    {
        if (!shopPanel.activeInHierarchy)//jeśli nie jesteśmy w sklepie
        {
            if (this.itemSlot.item == null)//jeśli nic nie ma w aktualnie przechowywanym polu
            {
                this.itemSlot.Copy(itemSlot); //to kopiuje do niego item
                itemSlot.Clear();//czyści pole, z którego było przeniesione
            }
            else//jeśli w "schowku" jest item
            {
                Item item = this.itemSlot.item;//przechowuje slot ze "schowka"     
                int count = this.itemSlot.count;// j.w. c.d.

                this.itemSlot.Copy(itemSlot);//kopiuje do "schowka" kliknięty item
                itemSlot.Set(item, count, container); //w miejsce klikniętego wstawia ten, który był wcześniej w schowku
            }
            UpdateIcon();
        }
            
    }

    private void UpdateIcon()
    {
        if(itemSlot.item == null)//jeśli nic nie jest przeciągane
        {
            dragItemIcon.SetActive(false);
        }
        else//jeśli jest przeciągane
        {
            dragItemIcon.SetActive(true); //aktywuje się obrazek
            iconImage.sprite = itemSlot.item.icon;//obrazek jest taki jak ikona przeciąganego przedmiotu
        }
    }
}
