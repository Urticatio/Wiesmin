using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventController : MonoBehaviour
{   
    public GameObject eventTextObject;
    public GameObject eventDescriptionTextObject;
    private Text eventTextField;
    private Text eventDescriptionTextField;
    private void Start()
    {
        eventTextField = eventTextObject.GetComponent<Text>();
        eventDescriptionTextField = eventDescriptionTextObject.GetComponent<Text>();
        ShowEvent("Tablica ogłoszeniowa", "Znajdź tablicę ogłoszeniową w pobliżu domu", 5);
    }

    public void ShowEvent(string eventText, string descriptionText, int seconds)
    {
        eventTextField.text = eventText;
        eventDescriptionTextField.text = descriptionText;
        //eventTextObject = eventTextField.GetComponent<GameObject>();
        eventTextObject.SetActive(true); //pokazuje pole tekstowe
        eventDescriptionTextObject.SetActive(true);
        StartCoroutine(HideEvent(seconds));
    }

    IEnumerator HideEvent(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        eventTextObject.SetActive(false); //chowa pole tekstowe
        eventDescriptionTextObject.SetActive(false);
    }
}
