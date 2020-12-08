using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    public static ItemSpawnManager instance;//statyczne

    private void Start()
    {
        instance = this;
    }

    [SerializeField] GameObject pickUpItemPrefab;
    public void SpawnItem(Vector3 position, Item item, int count)
    {
        GameObject o = Instantiate(pickUpItemPrefab, position, Quaternion.identity); //tworzy obiekt
        o.GetComponent<PickUpItem>().Set(item, count);
    }
}
