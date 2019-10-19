﻿using System.Collections;
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

        if (Time_Handler.currentHour >= newsHour && !visitedNewsMorning && !isBusy)
        {
            GoVisitNews();
        }

        if (Time_Handler.currentHour >= stocksHour && !visitedStocksMorning && !isBusy)
        {
            GoVisitStocks();
        }

        if (Time_Handler.currentHour >= homeTime && !isBusy && !atHome)
        {
            GoHome();
        }

        if (currentTask == TaskType.News)
        {
            if (Time_Handler.currentHour >= taskStartHour + timeSpentAtNewsMax && Time_Handler.currentTime >= taskStartTime)
            {
                isBusy = false;
                currentTask = TaskType.Wander;
            }
        }

        if (currentTask == TaskType.Stocks)
        {
            if (Time_Handler.currentHour >= taskStartHour + timeSpentAtStocksMax && Time_Handler.currentTime >= taskStartTime)
            {
                isBusy = false;
                currentTask = TaskType.Wander;
            }
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

}
