using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//klasa, której obiekt zapisujemy przy zapisywaniu stanu gry
[System.Serializable]
public class Save
{
    //zapisywane rzeczy
    public int currentQuest;

    public Save(int currQuest)
    {
        currentQuest = currQuest;
    }
}

