using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    [SerializeField] private Bar staminaBar;
    [SerializeField] private Bar healthBar;
    void Start()
    {
        staminaBar.SetSize(100);
        healthBar.SetSize(100);
    }

    void Update()
    {
        if (staminaBar.getBarState() < 0) //gdy wytrzymałość spadnie poniżej 0
        {
            staminaBar.SetSize(0);
            healthBar.Subtract(3); //utrata żywotności
        }
        if (healthBar.getBarState() <= 0)
        {
            healthBar.SetSize(1);
            if(staminaBar.getBarState()==0) UnityEditor.EditorUtility.DisplayDialog(" ", "Umarłeś z przemęczenia... Przy następnej rozgrywce pamiętaj o odpowiednim odpoczynku.", "Wyjdź z gry", "Zamknij");
        }
    }

    public void Regenerate() //odnawia życie i wytrzymałość
    {
        staminaBar.SetSize(100);
        healthBar.SetSize(100);
    }
}
