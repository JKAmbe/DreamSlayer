using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountMovement : MonoBehaviour
{
    public CheckMovement cm1;
    public CheckMovement cm2;
    public CheckMovement cm3;
    public CheckMovement cm4;
    public CheckMovement cm5;
    public CheckMovement cm6;
    public CheckMovement cm7;
    public CheckMovement cm8;
    public CheckMovement cm9;
    public CheckMovement cm10;
    public CheckMovement cm11;
    public CheckMovement cm12;
    public bool total = false;

    void Update()
    {
        if (cm1.clicked && cm2.clicked && cm3.clicked && 
            cm4.clicked && cm5.clicked && cm6.clicked && 
            cm7.clicked && cm8.clicked && cm9.clicked && 
            cm10.clicked && cm11.clicked && cm12.clicked)
        {
            total = true;
            Debug.Log("Total = " + total);
        }
    }
}
