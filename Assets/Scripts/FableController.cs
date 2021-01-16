using System.Collections;
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
    private SpriteRenderer boardSpriteRenderer;
    private Sprite signNewSprite;
    private Sprite signStandardSprite;

    private readonly string [] titles = new string[] 
    {
        "Miłe upraw początki",
        "Miecze i pomidory",
        "Tajemnica znikających marchewek"
    };
    private readonly string [] bodies = new string[]
    {
        "Po trudach wiedźmińskiego życia, Geralt postanowił rzucić wszystko i wyjechać do Białego Sadu. " +
        "Postanowił wieść spokojne życie z dala od problemów wielkiego świata i nękających go potworów. " +
        "Od dzisiaj musi się jednak zabrać do pracy w polu i w ten sposób zapracować na utrzymanie." +
        "\n\n",

        "",

        ""

    };
    private readonly string[] quests = new string[]
    {
        "Zadania do wykonania:\n" +
        "- Odnajdź miejsce, na którym można prowadzić uprawy.\n" +
        "- Zaoraj pole, zasadź marchew, codziennie podlewaj.\n" +
        "- Zbierz pierwsze plony.",

        "",

        ""
    };

    void Awake()
    {
        boardSpriteRenderer = announcementBoardSign.GetComponent<SpriteRenderer>();
        signNewSprite = signNew.GetComponent<SpriteRenderer>().sprite;
        signStandardSprite = signStandard.GetComponent<SpriteRenderer>().sprite;

        //na początku pierwsze zadanie
        ChangeSignSpriteToNew();
        titleText.text = titles[0];
        bodyText.text = bodies[0];
        questText.text = quests[0];
    }
    void Update()
    {
        
    }

    public void ChangeSignSpriteToNew()
    {
        boardSpriteRenderer.sprite = signNewSprite;
    }
    public void ChangeSignSpriteToStandard()
    {
        boardSpriteRenderer.sprite = signStandardSprite;
    }
}
