using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class DayTimeController : MonoBehaviour
{
    const float secoundsInDay = 86400f;
    const int phaseLength = 1;// every 15 min in game wake up all agents

    [SerializeField] Color nightLightColor;
    [SerializeField] AnimationCurve nightTimeCurve;
    [SerializeField] Color dayLightColor = Color.white;

    float time;
    [SerializeField] float timeScale = 600f;
    [SerializeField] float startAtTime = 28800f;//sec
    [SerializeField] Text text;
    [SerializeField] Light2D globalLight;
    private int days;

    List<TimeAgent> agents;

    private void Awake()
    {
        agents = new List<TimeAgent>();
    }
    private void Start()
    {
        time = startAtTime;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))//po wciśnięciu 'n' zmienia się dzień -- do użytku pokazowo-programistycznego
        {
            Sleep();
        }

        time += Time.deltaTime * timeScale;

        TimeValueCalculation();
        DayLight();

        if (time > secoundsInDay)
        {
            NextDay();
        }
        TimeAgents();
    }   

    public void Subscribe(TimeAgent timeAgent)
    {
        agents.Add(timeAgent);
    }
    public void Unsubscribe(TimeAgent timeAgent)
    {
        agents.Remove(timeAgent);
    }
    float Hours
    {
        get { return time / 3600f;  }
    }

    public int GetHour()
    {
        return (int)Hours;
    }
    float Minutes
    {
        get { return time % 3600f / 60f; }
    }

    //
    //public delegate void EndOfDay();
    //public static event EndOfDay OnEndOfDay;
    //
    public void Sleep()
    {
        NextDay();
        time += 3600*5; //spanie do 5 rano
    }
    
    private void TimeValueCalculation()
    {   
        int hh = (int)Hours;
        int mm = (int)Minutes;
        text.text = "Day " + days.ToString() + ", Time: " + hh.ToString("00") + ":" + "00";
    }
    private void DayLight()
    {
        float v = nightTimeCurve.Evaluate(Hours);
        Color c = Color.Lerp(dayLightColor, nightLightColor, v);
        globalLight.color = c;
    }
    int oldPhase = 0;
    private void TimeAgents()
    {
        int currentPhase = (int)(days / phaseLength);
        Debug.Log(currentPhase);
        if(oldPhase != currentPhase)
        {
            oldPhase = currentPhase;
            foreach (var agent in agents)
            {
                agent.Invoke();
            }
        }
       
    }
    private void NextDay()
    {
        time = 0;
        days += 1;
        //if(OnEndOfDay != null) OnEndOfDay();
    }
}
