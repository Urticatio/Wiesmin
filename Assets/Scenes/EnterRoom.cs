using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRoom : MonoBehaviour
{

    public GameObject Portal;
    public GameObject Player;
    public bool isExitDoor;

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(Teleport());
    }


    IEnumerator Teleport()
    {
        int space_before_door = 2;
        if (isExitDoor)
            space_before_door = -2;

        yield return new WaitForSeconds(1);
        Player.transform.position = new Vector2(Portal.transform.position.x, Portal.transform.position.y + space_before_door);
    }
}