using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// przechowuje rzeczy, które chcemy zapisywać

public class SaveLoadController : MonoBehaviour
{
    private SaveLoad saveLoad; 

    //referencje do obiektów, w których coś jest zmieniane
    public FableController fableController;
    

    void Start()
    {
        saveLoad = GetComponent<SaveLoad>();
    }

    public void LoadGameState(Save save)
    {
        fableController.SetCurQuest(save.currentQuest);
    }

   public Save makeSaveData() //zwraca obiekt klasy Save, z aktualnymi parametrami gry
    {
        Save save = new Save(
            fableController.GetCurQuest()
            );
        return save;
    }
}
