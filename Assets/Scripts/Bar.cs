using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//skrypt obsługujący pasek wytrzymałości
public class Bar : MonoBehaviour
{
    private Transform bar;
    private float barState;//stan paska (0-100)

    void Awake()
    {
        bar = transform.Find("Bar");//znajduje w obiekcie właściwy pasek (obiekt o nazwie "Bar")
        barState = 100;
    }

    public void SetSize(float size)//ustawia stan paska
                                   //przyjmuje wartość z przedziału 0-100 
    {
        bar.localScale = new Vector3(size/100, 1f);
        barState = size;
    }
    
    public void Subtract(float value) //odejmuje wartość z paska (0-100)
    {
        barState -= value;
        this.SetSize(barState);
    }
    public void Add(float value) //dodaje wartość do paska (0-100)
    {
        barState += value;
        this.SetSize(barState);
    }
    public float getBarState()
    {
        return this.barState;
    }
}
