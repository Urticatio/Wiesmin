using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//zawiera metodę do tworzenia itemków na mapie

public class ItemSpawnManager : MonoBehaviour
{
    public static ItemSpawnManager instance;//statyczne

    private void Start()
    {
        instance = this;
    }

    [SerializeField] GameObject pickUpItemPrefab;
    [SerializeField] GameObject cropPrefab;
    public void SpawnItem(Vector3 position, Item item, int count, bool isCrop)
    {
        if (isCrop)
        {
            GameObject o = Instantiate(cropPrefab, position, Quaternion.identity); //tworzy obiekt (de facto kopiuje)
            o.GetComponent<PickUpItem>().Set(item, count); //ustawia jaki to item i ile go jest
        }
        else
        {
            GameObject o = Instantiate(pickUpItemPrefab, position, Quaternion.identity); //tworzy obiekt (de facto kopiuje)
            o.GetComponent<PickUpItem>().Set(item, count); //ustawia jaki to item i ile go jest
        }
    }
}
