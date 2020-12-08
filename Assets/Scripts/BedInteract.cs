using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;

public class BedInteract : Interactable
{

    public override void Interact(Character character)
    {
        System.Diagnostics.Debug.WriteLine("interacting with bed");
    }
}
