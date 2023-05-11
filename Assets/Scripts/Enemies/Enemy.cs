using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //Common functionalities for all enemies
    protected NavMeshAgent navMeshAgent;
    protected GameObject player;

    [SerializeField] private float recalculateRouteToPlayerThreshold = 1f;
    [SerializeField] protected float approachingRange = 10f;
    [SerializeField] private LayerMask sightMask;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    //Moves in the direction of player until it is in range and on sight
    protected bool MoveUntilPlayerInRangeAndOnSight()
    {
        if(Vector3.Distance(transform.position, player.transform.position) <= approachingRange)
        {
            navMeshAgent.SetPath(null);
            return true;
        }

        if(Vector3.Distance(player.transform.position, navMeshAgent.destination) > recalculateRouteToPlayerThreshold)
        {
            navMeshAgent.SetDestination(player.transform.position);
        }

        return false;
    }
}
