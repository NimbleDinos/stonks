using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Navigation : MonoBehaviour
{
    public Transform homePoint;
    public List<Transform> stockMarketTerminals, newsStands;

    public NavMeshAgent agent;
    public bool inMotion = false;

    public AI_Schedule schedule;

    private Transform currentDestination;

    private TaskType intendedTask = TaskType.Wander;

    private void Start()
    {
        currentDestination = homePoint;
        agent.SetDestination(currentDestination.position);
        inMotion = true;
    }

    public void Update()
    {
        if (transform.position.x == currentDestination.position.x && transform.position.z == currentDestination.position.z && inMotion)
        {
            inMotion = false;
            agent.isStopped = true;
            schedule.currentTask = intendedTask;
            schedule.taskStartHour = Time_Handler.currentHour;
            schedule.taskStartTime = Time_Handler.currentTime;
        }
    }

    public void SetTarget(Transform target, TaskType taskIntended)
    {
        currentDestination = target;
        agent.SetDestination(currentDestination.position);
        agent.isStopped = false;
        inMotion = true;
        intendedTask = taskIntended;
    }

    public Transform FindNearestNewsStand()
    {
        Transform nearestTarget = null;
        float currentDist = Mathf.Infinity;

        if (newsStands.Count > 0)
        {
            foreach (Transform newsStand in newsStands)
            {
                float dist = Vector3.Distance(transform.position, newsStand.position);

                if (dist < currentDist)
                {
                    nearestTarget = newsStand;

                    currentDist = dist;
                }
            }
        }
        //Access List of news stands
        //Determine closest one to agent
        
        return nearestTarget;
    }
}
