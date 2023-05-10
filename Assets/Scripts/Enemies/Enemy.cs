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

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    //Moves in the direction of player until it is on sight
    protected bool GetPlayerOnSight()
    {
        if(Physics.Raycast)
        if(Vector3.Distance(player.transform.position, navMeshAgent.destination) > recalculateRouteToPlayerThreshold)
        {
            navMeshAgent.SetDestination(player.transform.position);
        }
    }
}
