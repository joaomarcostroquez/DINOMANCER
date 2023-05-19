using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float recalculateRouteToPlayerThreshold = 1f;
    [SerializeField] protected float approachingRange = 10f;
    [SerializeField] private float navRaycastAroundPlayerDistance = 1f;

    protected NavMeshAgent navMeshAgent;
    protected GameObject player;

    private Vector3[] navRaycastsAroundPlayerDirections = { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(-1, 0, 0), new Vector3(0, 0, 1), new Vector3(0, 0, -1) };

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    //Moves in the direction of player until it is in range and on sight
    protected bool MoveUntilPlayerInRangeAndOnSight()
    {
        NavMeshHit hit;
        bool playerOnSight = false;

        foreach(Vector3 checkPosition in navRaycastsAroundPlayerDirections)
        {
            if(!navMeshAgent.Raycast(player.transform.position + checkPosition * navRaycastAroundPlayerDistance, out hit))
            {
                playerOnSight = true;
                break;
            }
        }

        if(HorizontalDistance(transform.position, player.transform.position) <= approachingRange && playerOnSight)
        {
            navMeshAgent.ResetPath();

            return true;
        }

        if(HorizontalDistance(player.transform.position, navMeshAgent.destination) > recalculateRouteToPlayerThreshold)
        {
            navMeshAgent.SetDestination(player.transform.position);
        }

        return false;
    }

    private float HorizontalDistance(Vector3 a, Vector3 b)
    {
        return Vector2.Distance(new Vector2(a.x, a.z), new Vector2(b.x, b.z));
    }
}
