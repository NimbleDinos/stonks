using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Navigation : MonoBehaviour
{
    public Transform homePoint;
    public List<Transform> businessLocations, stockMarketTerminals, newStands;

    public NavMeshAgent agent;
    public bool inMotion = false;

    private Transform currentDestination;

    private void Start()
    {
        currentDestination = homePoint;
    }

    public void Update()
    {
        if (transform.position.x == currentDestination.position.x && transform.position.z == currentDestination.position.z)
        {
            int rand = Random.Range(0, businessLocations.Count);

            currentDestination = businessLocations[rand];

            inMotion = false;
        }

        if (!inMotion)
        {
            agent.SetDestination(currentDestination.position);

            inMotion = true;
        }
    }
}
