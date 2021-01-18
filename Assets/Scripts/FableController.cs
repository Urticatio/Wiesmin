﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class FableController : MonoBehaviour
{
    [SerializeField] Text titleText;
    [SerializeField] Text bodyText;
    [SerializeField] Text questText;
    [SerializeField] GameObject announcementBoardSign;
    [SerializeField] GameObject signNew;
    [SerializeField] GameObject signStandard;
    [SerializeField] int currentQuest; //numer aktualnego questa
    private SpriteRenderer boardSpriteRenderer;
    private Sprite signNewSprite;
    private Sprite signStandardSprite;
    private bool showedNewQuest;//czy pokazano informację o nowym queście
    private bool readSignFirstTime = false;//czy wyświetlono pierwszy raz tablicę ogłoszeniową
    private EventController eventController;

    private readonly string [] titles = new string[] 
    {
        "Miłe upraw początki",
        "Miecze i pomidory",
        "Tajemnica znikających marchewek",
        "Królikołak"
    };
    private readonly string [] bodies = new string[]
    {
        "Po trudach wiedźmińskiego życia, Geralt postanowił rzucić wszystko i wyjechać do Białego Sadu. " +
        "Postanowił wieść spokojne życie z dala od problemów wielkiego świata i nękających go potworów. " +
        "Od dzisiaj musi się jednak zabrać do pracy w polu i w ten sposób zapracować na utrzymanie." +
        "\n\n",

        "Uprawa warzyw, to było to, czego Geraltowi brakowało. Nie samą jednak marchwią człowiek żyje. Może by zasadzić pomidory?\n" +
        "Mimo braku niebezpieczeństw i czyhających za rogiem potworów, Geralt czuje się nieswojo bez żadnego oręża. Na szczęście zadbał o łącze światłowodowe w swoim nowym domu. Czas zarobić pieniądze i kupić miecz w sklepie internetowym." +
        "\n\n",

        "Pewnego dnia, Geralt zauważył czyjeś ślady na farmie. Niektóre grządki były naruszone, a rośliny wyrwane.\n" +
        "Okazuje się, że ucierpiała jedynie uprawa marchwi. Wszystko wskazuje na pojawienie się w okolicy Królikołaka.\n" +
        "Chcąc nie chcąc, Geralt postanowił zwabić potwora i się z nim rozprawić." +
        "\n\n",

        "Zaczekaj na farmie do wieczora i rozpraw się z potworem. \n\n"

    };
    private readonly string[] quests = new string[]
    {
        "Zadania do wykonania:\n" +
        "- Odnajdź miejsce, na którym można prowadzić uprawy.\n" +
        "- Zaoraj pole, zasadź marchew, codziennie podlewaj.\n" +
        "- Zbierz pierwsze plony.",

        "Zadania do wykonania:\n" +
        "- Posadź pomidory, ich cena w sklepie jest wyższa niż marchwi.\n" +        
        "- Skorzystaj ze sklepu internetowego w domu.\n" +
        "- Kup odpowiedni oręż." ,

        "Zadania do wykonania:\n" +
        "- Zbierz 100 marchewek jako przynętę na Królikołaka.\n" +
        "- [Opcjonalnie] Kup lepszą broń.",

        "Zadania do wykonania:\n" +
        "- Pokonaj Królikołaka."
    };

    void Awake()
    {
        eventController = GameManager.instance.eventController;
        boardSpriteRenderer = announcementBoardSign.GetComponent<SpriteRenderer>();
        signNewSprite = signNew.GetComponent<SpriteRenderer>().sprite;
        signStandardSprite = signStandard.GetComponent<SpriteRenderer>().sprite;

        //na początku pierwsze zadanie
        currentQuest = 0;
        ChangeSignSpriteToNew();
        SetSignText(titles[currentQuest], bodies[currentQuest], quests[currentQuest]);
        showedNewQuest = false;
    }
    void Update()
    {
        if (readSignFirstTime)
        {
            eventController.ShowEvent("Nowe zadanie", titles[currentQuest],5);
            showedNewQuest = true;
            readSignFirstTime = false;
        }
        else if ((currentQuest == 1) && (!showedNewQuest))
        {
            eventController.ShowEvent("Nowe zadanie", titles[currentQuest], 5);
            ChangeSignSpriteToNew();
            SetSignText(titles[currentQuest], bodies[currentQuest],quests[currentQuest]);
            showedNewQuest = true;
        }
        else if ((currentQuest == 2) && (!showedNewQuest))
        {
            eventController.ShowEvent("Nowe zadanie", titles[currentQuest], 5);
            ChangeSignSpriteToNew();
            SetSignText(titles[currentQuest], bodies[currentQuest], quests[currentQuest]);
            showedNewQuest = true;
        }

        //******TODO******
        if (false)//sprawdzanie, czy jest 100 marchewek
        {
            NextQuest();
        }
        //*************
    }

    private void SetSignText(string title, string body, string quest)
    {
        titleText.text = title;
        bodyText.text = body;
        questText.text = quest;
    }


    public void ChangeSignSpriteToNew()
    {
        boardSpriteRenderer.sprite = signNewSprite;
    }
    public void ChangeSignSpriteToStandard()
    {
        boardSpriteRenderer.sprite = signStandardSprite;
    }

    public int GetCurQuest()
    {
        return currentQuest;
    }
    public void NextQuest()
    {
        currentQuest++;
        showedNewQuest = false;
    }

    public void ReadSignFirstTime()
    {
        readSignFirstTime = true;
    }
}
