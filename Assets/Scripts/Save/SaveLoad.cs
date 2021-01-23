using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[RequireComponent(typeof(SaveLoadController))]
public class SaveLoad : MonoBehaviour
{
    private SaveLoadController slController;
    private string savePath;

    void Start()
    {
        slController = GetComponent<SaveLoadController>();
        savePath = Application.persistentDataPath + "Wiesmin.save";
    }

    public void SaveData()
    {
        var save = slController.makeSaveData();
    
        var binaryFormatter = new BinaryFormatter();

        using (var fileStream = File.Create(savePath))
        {
            binaryFormatter.Serialize(fileStream, save);
        }

        Debug.Log("Data saved");
    }

    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            Save save;

            var binaryFormatter = new BinaryFormatter();

            using (var fileStream = File.Open(savePath, FileMode.Open))
            {
                save = (Save)binaryFormatter.Deserialize(fileStream);
            }

            slController.LoadGameState(save);

            Debug.Log("Data Loaded");
        }
        else
        {
            Debug.LogWarning("Save file does not exist");
        }
    }
}
