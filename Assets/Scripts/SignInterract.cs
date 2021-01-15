using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInterract : Interactable
{
    [SerializeField] GameObject signPanel;//referencja do panelu tablicy ogłoszeniowej
    [SerializeField] GameObject inventoryPanel;
    public override void Interact(Character character)
    {
        if (signPanel.activeInHierarchy || !inventoryPanel.activeInHierarchy)
        {
            signPanel.SetActive(!signPanel.activeInHierarchy);//włącza ekwipunek i sklep
        }
    }
}
