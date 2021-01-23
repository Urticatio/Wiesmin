using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// przechowuje rzeczy, które chcemy zapisywać

public class SaveLoadController : MonoBehaviour
{
    public SaveLoad saveLoad; 
    public GameObject rabbitPrefab;

    //referencje do obiektów, w których coś jest zmieniane
    private FableController fableController;
    

    void Start()
    {
        fableController = GameManager.instance.fableController;
        saveLoad = GameManager.instance.saveLoadController.saveLoad;
    }

   public Save makeSaveData() //zwraca obiekt klasy Save, z aktualnymi parametrami gry       
    {//ten obiekt się zapisuje
        Save save = new Save(
            fableController.GetCurQuest(),
            fableController.readSignFirstTime,
            fableController.defeatedRabbit,
            GameManager.instance.player.transform.position.x,
            GameManager.instance.player.transform.position.y,
            GameManager.instance.money
            );
        return save;
    }

    public void SaveGame()
    {
        saveLoad.SaveData();
        GameManager.instance.eventController.ShowEvent("Gra zapisana", "", 5);
    }
    public void LoadGame()
    {
        saveLoad.LoadData();
    }
    public void LoadGameState(Save save)//ustawia odpowiednie parametry
    {
        fableController.SetCurQuest(save.currentQuest);
        fableController.readSignFirstTime = save.readSign;

        if (fableController.defeatedRabbit)//jeśli pokonano aktualnie
        {
            if(!save.defeatedRabbit)//jeśli w zapisie nie pokonano
            {//to spawnuje królika, żeby był
                GameObject rabbit = Instantiate(rabbitPrefab);
                GameManager.instance.monster = rabbit;
            }
        }
        fableController.defeatedRabbit = save.defeatedRabbit;

        GameManager.instance.player.transform.position = new Vector3(save.playerX, save.playerY, 0);
        GameManager.instance.money = save.money;
        GameManager.instance.eventController.ShowEvent("Wczytano zapis", fableController.titles[save.currentQuest], 5);
    }
}
