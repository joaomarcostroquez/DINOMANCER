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
        for(int i = 0; i < 3; i++)
        {
            //player.transform.position[i]
            //navmesh agent raycast to player, if theres an obstacle raycast around player using error variable to permit rushing to player even when he is near to a wall
        }

        if(HorizontalDistance(transform.position, player.transform.position) <= approachingRange && !navMeshAgent.Raycast(player.transform.position, out NavMeshHit hit))
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
