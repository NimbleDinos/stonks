using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TaskType {News, Stocks, Home, Wander, Work};

public class AI_Schedule : MonoBehaviour
{
    public int newsHour = 8, newsClose = 20, stocksHour = 10, stocksClose = 20, homeTime = 21, timeSpentAtStocksMax = 1, timeSpentAtNewsMax = 1, workStart = 8, workEnd = 17;

    public TaskType currentTask = TaskType.Wander;

    public AI_Navigation agentNav;

    private bool recentlyVisitedNews = false, atHome = true, isBusy = false;
    [HideInInspector]
    public bool shouldVisitStocks = false;

    private bool startedDay = false;

    [HideInInspector]
    public float taskStartTime = 0.0f;
    [HideInInspector]
    public int taskStartHour = 0;

    public float wanderTimerMax = 5.0f;
    private float wanderTimeCurrent = 0.0f;

    public int timeBetweenNewsVisits = 4;

    [HideInInspector]
    public int timeVisitedNews = 0;

    public MeshRenderer mr;

    public bool isTrader = true;

    public bool beenToWork = false;

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

        if (recentlyVisitedNews)
        {
            if (Time_Handler.currentHour >= timeVisitedNews + timeBetweenNewsVisits)
            {
                recentlyVisitedNews = false;
            }
        }
    

        if (!isBusy)
        {
            if (Time_Handler.currentHour >= newsHour && !recentlyVisitedNews && Time_Handler.currentHour < newsClose && isTrader)
            {
                GoVisitNews();
            }

            if (Time_Handler.currentHour >= stocksHour && shouldVisitStocks && Time_Handler.currentHour < stocksClose && isTrader)
            {
                GoVisitStocks();
            }

            if (Time_Handler.currentHour >= homeTime && !atHome)
            {
                GoHome();
            }

            if (Time_Handler.currentHour >= workStart && !beenToWork && !isTrader)
            {
                GoToWork();
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
            case TaskType.Work:
                if (beenToWork && Time_Handler.currentHour >= workEnd)
                {
                    currentTask = TaskType.Wander;
                    atHome = false;
                    isBusy = false;
                }
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
        recentlyVisitedNews = false;
        beenToWork = false;
        shouldVisitStocks = false;
    }

    private void GoVisitNews()
    {
        Debug.Log("Visiting News");

        recentlyVisitedNews = true;
        isBusy = true;
        atHome = false;

        int rand = Random.Range(0, agentNav.newsStands.Count);
        agentNav.SetTarget(agentNav.newsStands[rand], TaskType.News);
    }

    private void GoVisitStocks()
    {
        Debug.Log("Visiting Stock Exchange");

        shouldVisitStocks = false;
        isBusy = true;
        atHome = false;

        agentNav.SetTarget(agentNav.stockMarketPoint, TaskType.Stocks);
    }

    private void GoHome()
    {
        agentNav.SetTarget(agentNav.homePoint, TaskType.Home);
        atHome = true;
    }
    private void GoToWork()
    {
        agentNav.SetTarget(agentNav.workPoint, TaskType.Work);
        currentTask = TaskType.Work;
        isBusy = true;
        beenToWork = true;
        atHome = false;
    }

    private void Wander()
    {
        agentNav.SetWanderTarget();
        isBusy = false;
        atHome = false;
    }

    //TODO determine if news is worthwhile
}
