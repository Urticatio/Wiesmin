using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDropController : MonoBehaviour
{
    [SerializeField] ItemSlot itemSlot; //"przechowywany" item
    [SerializeField] GameObject dragItemIcon; //ikona przeciąganego itemka
    RectTransform iconTransform; //przechowuje pozycje itp. ikonki
    Image iconImage; 

    private void Start()
    {
        itemSlot = new ItemSlot();
        iconTransform = dragItemIcon.GetComponent<RectTransform>();
        iconImage = dragItemIcon.GetComponent<Image>();
    }

    private void Update()
    {
        if(dragItemIcon.activeInHierarchy == true)//jeśli ikona przeciąganego obiektu jest widoczna
        {
            iconTransform.position = Input.mousePosition; //przypisuje pozycję myszy ikonce

            if (Input.GetMouseButtonDown(0))//jeśli lewy przycisk myszy jest wciśnięty
            {
                if (EventSystem.current.IsPointerOverGameObject() == false)//jeśli kursor nie jest nad aktualnym obiektem EventSystem
                {                    
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);//konwertuje pozycję myszy na pozycję na mapie
                    worldPosition.z = 0;//żeby się przypadkiem nie pojawiło za mapą                 
                    ItemSpawnManager.instance.SpawnItem(//upuszcza w tym miejscu przedmiot
                        worldPosition,
                        itemSlot.item,
                        itemSlot.count);
                    itemSlot.Clear();//czyści pole po wyrzuceniu
                    dragItemIcon.SetActive(false);//chowa ikonę po upuszczeniu przedmiotu
                }
            }
            
        }
    }

    internal void OnClick(ItemSlot itemSlot)//przyjmuje "kliknięty" item
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
            itemSlot.Set(item, count); //w miejsce klikniętego wstawia ten, który był wcześniej w schowku
        }
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if(itemSlot.item == null)//jeśli nic nie jest przeciągane
        {
            dragItemIcon.SetActive(false);
        }
        else//jeśli jest przeciągane
        {
            dragItemIcon.SetActive(true); //aktywuje się obrazek (podążający za myszą)
            iconImage.sprite = itemSlot.item.icon;//obrazek jest taki jak ikona przeciąganego przedmiotu
        }
    }
}
