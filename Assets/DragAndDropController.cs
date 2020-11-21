using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropController : MonoBehaviour
{
    [SerializeField] ItemSlot itemSlot; //"przechowywany" item

    private void Start()
    {
        itemSlot = new ItemSlot();
    }

    internal void OnClick(ItemSlot itemSlot)//przyjmuje "kliknięty" item
    {
        if(this.itemSlot.item == null)//jeśli nic nie ma w aktualnie przechowywanym polu
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
    }
}
