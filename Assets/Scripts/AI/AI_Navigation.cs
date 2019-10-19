using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Navigation : MonoBehaviour
{
    public Transform homePoint, workPoint;
    public List<Transform> stockMarketTerminals, newsStands, leisureLocations;

    public NavMeshAgent agent;
    public bool inMotion = false;

    public AI_Schedule schedule;

    private Vector3 currentDestination;

    private TaskType intendedTask = TaskType.Wander;

    private List<Transform> wanderList;
    
    private void Start()
    {
        currentDestination = homePoint.position;
        agent.SetDestination(currentDestination);
        inMotion = true;

        wanderList = new List<Transform>();
        wanderList.AddRange(newsStands);
        wanderList.AddRange(leisureLocations);

        //TODO wander to stock excahnge for traders?
    }

    public void Update()
    {
        if (transform.position.x == currentDestination.x && transform.position.z == currentDestination.z && inMotion)
        {
            inMotion = false;
            agent.isStopped = true;
            schedule.currentTask = intendedTask;
            schedule.taskStartHour = Time_Handler.currentHour;
            schedule.taskStartTime = Time_Handler.currentTime;

            if (schedule.currentTask == TaskType.Wander)
            {
                SetWanderTarget();
            }
        }
    }

    public void SetTarget(Transform target, TaskType taskIntended)
    {
        currentDestination = target.position;
        agent.SetDestination(currentDestination);
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

    //public void SetWanderTarget()
    //{
    //    Vector3 target = GetNavMeshPosition(transform.position, 50.0f);
    //    intendedTask = TaskType.Wander;
        
    //    currentDestination = target;
    //    agent.SetDestination(currentDestination);
    //    agent.isStopped = false;
    //    inMotion = true;
    //}

    public void SetWanderTarget()
    {
        int rand = Random.Range(0, wanderList.Count);
        Vector3 target = wanderList[rand].position;
        intendedTask = TaskType.Wander;
        
        currentDestination = target;
        agent.SetDestination(currentDestination);
        agent.isStopped = false;
        inMotion = true;
    }

    public Vector3 GetNavMeshPosition(Vector3 origin, float distance)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;

        int layerMask = -1;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layerMask);

        return navHit.position;
    }
}
