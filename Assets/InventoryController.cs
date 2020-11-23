using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] GameObject panel; //referencja do panelu ekwipunku

    private void Start()
    {
        panel.SetActive(false);//na starcie wyłącza ekwipunek
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))//po wciśnięciu 'i'
        {
            panel.SetActive(!panel.activeInHierarchy);//panel zmienia swój status aktywności (dlatego zaprzeczamy stanowi obecnemu)
        }
    }

}
