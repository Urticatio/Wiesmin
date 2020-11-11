﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRoom : MonoBehaviour
{

    public GameObject Portal;
    public GameObject Player;
    public bool isExitDoor;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.tag == "MainCharacter")
        //{
            StartCoroutine(Teleport());
        //}
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