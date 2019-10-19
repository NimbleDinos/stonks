using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Schedule : MonoBehaviour
{
    public int newsHour = 8;

    private bool visitedNewsMorning = false;

    private void Start()
    {
        StartNewDay();
    }

    public void StartNewDay()
    {
        visitedNewsMorning = false;
    }
}
