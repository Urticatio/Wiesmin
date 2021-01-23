using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//klasa, której obiekt zapisujemy przy zapisywaniu stanu gry
[System.Serializable]
public class Save
{
    //zapisywane rzeczy
    public int currentQuest;
    public bool readSign;
    public bool defeatedRabbit;
    public float playerX;
    public float playerY;
    public int money;

    public Save(int currQuest, bool rdSign, bool defRab, float plrX, float plrY, int mon)
    {
        currentQuest = currQuest;
        readSign = rdSign;
        defeatedRabbit = defRab;
        playerX = plrX;
        playerY = plrY;
        money = mon;
    }
}

