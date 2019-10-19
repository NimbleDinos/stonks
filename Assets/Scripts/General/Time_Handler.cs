using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Handler : MonoBehaviour
{
    public float timePerHour = 60.0f; //60.0f = 1 real-time minute per in-game hour

    public static int currentHour = 7;
    public static int currentDay = 0;
    public static float currentTime = 0.0f;

    //TODO broadcast to all agents start of new day  

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= timePerHour)
        {
            currentTime -= timePerHour;
            currentHour++;
            
            if (currentHour >= 24)
            {
                currentHour -= 24;
                currentDay++;
            }

            Debug.Log("Current Hour: " + currentHour);
        }
    }
}
