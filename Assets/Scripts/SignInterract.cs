using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInterract : Interactable
{
    [SerializeField] GameObject signPanel;//referencja do panelu tablicy ogłoszeniowej
    [SerializeField] GameObject inventoryPanel;
    private bool readSignFirstTime = false;
    public override void Interact(Character character)
    {
        if (signPanel.activeInHierarchy || !inventoryPanel.activeInHierarchy)
        {
            signPanel.SetActive(!signPanel.activeInHierarchy);//włącza ekwipunek i sklep
            GameManager.instance.fableController.ChangeSignSpriteToStandard();//zmienia wygląd znaku
            if ((!signPanel.activeInHierarchy) && (GameManager.instance.fableController.GetCurQuest() == 0) && (!readSignFirstTime))//jeśli jeszcze nie czytana
            {
                GameManager.instance.fableController.ReadSignFirstTime();
                readSignFirstTime = true;
            }
        }
        
    }
}
