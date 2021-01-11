using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//interakcja z komputerem
public class ComputerInterract : Interactable
{
    [SerializeField] GameObject panel;//referencja do panelu ekwipunku
    [SerializeField] GameObject toolbarPanel;
    [SerializeField] GameObject shopPanel;
    [SerializeField] GameObject priceTextField;
    public override void Interact(Character character)
    {
        if (toolbarPanel.activeInHierarchy || shopPanel.activeInHierarchy) //jeżeli przypadkiem ekwipunek nie jest otwarty, czyli wtedy gdy widać toolbar; albo gdy jest otwarty sklep, to działa
        {
            panel.SetActive(!panel.activeInHierarchy);//włączmy ekwipunek i sklep
            shopPanel.SetActive(!shopPanel.activeInHierarchy);
            toolbarPanel.SetActive(!toolbarPanel.activeInHierarchy); // wyłącza toolbar
            priceTextField.SetActive(!priceTextField.activeInHierarchy);
        }
    }
}
