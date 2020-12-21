using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    Transform player; //referencja do postaci
    [SerializeField] float speed = 0.05f; //szybkość "wciągania" przedmiotu
    [SerializeField] float pickUpDistance = 1.5f; // jak bardzo trzeba się zbliżyć do przedmiotu
    [SerializeField] float ttl = 10f; //time to leave, po jakim czasie niezebrany obiekt znika
    public Item item;
    public int count = 1;

    private void Start() //wywoływana, zanim Update po raz pierwszy
    {
        player = GameManager.instance.player.transform;
    }

    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = item.icon;//zmienia ikonę obiektu
    }

    private void Update() //wywoływana w każdej klatce gry
    { 
        float distance = Vector3.Distance(transform.position, player.position); //odległość przedmiotu od postaci
        if(distance > pickUpDistance) //jeśli jest za daleko od przedmiotu
        {
            return; //przerywa funkcję Update()
        }
        transform.position = Vector3.MoveTowards( //przesuwa
            transform.position,//przedmiot
            player.position, //w stronę postaci
            speed);//z takim krokiem (deltaTime to czas klatki gry)
        if(distance < 0.1f)
        {
            if (GameManager.instance.inventoryContainer != null)
            {
                GameManager.instance.inventoryContainer.Add(item, count, GameManager.instance.inventoryContainer);
                Debug.Log("Liczba przedmiotów zebranych: " + count);
            }
            else
            {
                Debug.LogWarning("No inventory container in game manager!");
            }
            Destroy(gameObject);
        }

    }
}
