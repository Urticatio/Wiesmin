using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] GameObject panel; //referencja do panelu ekwipunku
    [SerializeField] GameObject toolbarPanel;
    [SerializeField] GameObject shopPanel;

    private void Start()
    {
        panel.SetActive(false);//na starcie wyłącza ekwipunek
        shopPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))//po wciśnięciu 'i'
        {
            if (!shopPanel.activeInHierarchy) //jeżeli przypadkiem sklep nie jest otwarty
            {
                panel.SetActive(!panel.activeInHierarchy);//panel zmienia swój status aktywności (dlatego zaprzeczamy stanowi obecnemu)
                toolbarPanel.SetActive(!toolbarPanel.activeInHierarchy); // update toolbar
            }
            
        }
        if (Input.GetKeyDown(KeyCode.O))//po wciśnięciu 'o'
        {
            if (toolbarPanel.activeInHierarchy || shopPanel.activeInHierarchy) //jeżeli przypadkiem ekwipunek nie jest otwarty, czyli wtedy gdy widać toolbar; albo gdy jest otwarty sklep, to działa
            {
                panel.SetActive(!panel.activeInHierarchy);//włączmy ekwipunek i sklep
                shopPanel.SetActive(!shopPanel.activeInHierarchy);
                toolbarPanel.SetActive(!toolbarPanel.activeInHierarchy); // wyłącza toolbar
            }
        }
    }

}
