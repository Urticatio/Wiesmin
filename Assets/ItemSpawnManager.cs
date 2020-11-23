using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Item spawn manager")]
public class ItemSpawnManager : ScriptableObject
{
    public static ItemSpawnManager instance;//statyczne

    private void Start()
    {
        instance = this;
    }

    [SerializeField] GameObject pickUpItemPrefab;
    public void SpawnItem(Vector3 position, Item item, int count)
    {
        GameObject o = Instantiate(pickUpItemPrefab, position, Quaternion.identity);
        o.GetComponent<PickUpItem>().Set(item, count);
    }
}
