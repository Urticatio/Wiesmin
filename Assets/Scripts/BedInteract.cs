using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;

public class BedInteract : Interactable
{
    [SerializeField] DayTimeController dayTimeController;
    public override void Interact(Character character)
    {
        dayTimeController.Sleep();
        System.Diagnostics.Debug.WriteLine("interacting with bed");
    }
}
