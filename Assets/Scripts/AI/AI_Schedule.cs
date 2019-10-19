using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TaskType {News, Stocks, Home, Wander};

public class AI_Schedule : MonoBehaviour
{
    public int newsHour = 8, stocksHour = 10, homeTime = 21, timeSpentAtStocksMax = 1, timeSpentAtNewsMax = 1;

    public TaskType currentTask = TaskType.Wander;

    public AI_Navigation agentNav;

    private bool visitedNewsMorning = false, visitedStocksMorning = false, atHome = true, isBusy = false;
    
    private bool startedDay = false;

    public float taskStartTime = 0.0f;
    public int taskStartHour = 0;

    public float wanderTimerMax = 5.0f;
    private float wanderTimeCurrent = 0.0f;

    public MeshRenderer mr;

    public bool isTrader = true;

    private void Update()
    {
        if (Time_Handler.currentHour == 0 && !startedDay)
        {
            StartNewDay();
        }

        if (Time_Handler.currentHour == 1)
        {
            startedDay = false;
        }
    

        if (!isBusy)
        {
            if (Time_Handler.currentHour >= newsHour && !visitedNewsMorning)
            {
                GoVisitNews();
            }

            if (Time_Handler.currentHour >= stocksHour && !visitedStocksMorning)
            {
                GoVisitStocks();
            }

            if (Time_Handler.currentHour >= homeTime && !atHome)
            {
                GoHome();
            }
        }

        switch (currentTask)
        {
            case TaskType.News:
                if (Time_Handler.currentHour >= taskStartHour + timeSpentAtNewsMax && Time_Handler.currentTime >= taskStartTime)
                {
                    isBusy = false;
                    currentTask = TaskType.Wander;
                }
                break;
            case TaskType.Stocks:
                if (Time_Handler.currentHour >= taskStartHour + timeSpentAtStocksMax && Time_Handler.currentTime >= taskStartTime)
                {
                    isBusy = false;
                    currentTask = TaskType.Wander;
                }
                break;
            case TaskType.Wander:
                break;
            case TaskType.Home:
                break;
            default:
                break;
        }

        if (currentTask == TaskType.Home)
        {
            mr.enabled = false;
        }
        else
        {
            mr.enabled = true;
        }

    }

    public void StartNewDay()
    {
        startedDay = true;
        visitedNewsMorning = false;
        visitedStocksMorning = false;
    }

    private void GoVisitNews()
    {
        Debug.Log("Visiting News");

        visitedNewsMorning = true;
        isBusy = true;
        atHome = false;

        //agentNav.SetTarget(agentNav.FindNearestNewsStand());

        int rand = Random.Range(0, agentNav.newsStands.Count);
        agentNav.SetTarget(agentNav.newsStands[rand], TaskType.News);
    }

    private void GoVisitStocks()
    {
        Debug.Log("Visiting Stock Exchange");

        visitedStocksMorning = true;
        isBusy = true;
        atHome = false;

        //agentNav.SetTarget(agentNav.FindNearestStocksTerminal());

        int rand = Random.Range(0, agentNav.stockMarketTerminals.Count);
        agentNav.SetTarget(agentNav.stockMarketTerminals[rand], TaskType.Stocks);
    }

    private void GoHome()
    {
        agentNav.SetTarget(agentNav.homePoint, TaskType.Home);
        atHome = true;
    }

    private void Wander()
    {
        agentNav.SetWanderTarget();
    }

    /*TODO Wander, if in wander state, pick random valid location and begin 
     * walking their, after a few seconds pick new location and repeat until 
     * no longer wander state*/

}
