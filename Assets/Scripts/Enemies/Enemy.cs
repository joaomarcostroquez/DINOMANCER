using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public EnemyHealth health;

    [SerializeField] protected float activationRange = 20f;
    [SerializeField] protected float approachingRange = 10f;
    [SerializeField] private float recalculateRouteToPlayerThreshold = 1f;
    [SerializeField] private float navRaycastAroundPlayerDistance = 1f;

    [SerializeField] protected float contactDamage = 0f;
    [SerializeField] protected Vector2 contactDamageKnockback = Vector2.zero;
    [SerializeField] protected float contactDamageCoolDown = 1f;

    protected NavMeshAgent navMeshAgent;
    protected GameObject player;
    protected bool isActive = false;
    protected bool readyToDoContactDamage = true;

    private Vector3[] navRaycastsAroundPlayerDirections = { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(-1, 0, 0), new Vector3(0, 0, 1), new Vector3(0, 0, -1) };

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");

        if(contactDamage != 0 || contactDamageKnockback.x != 0 || contactDamageKnockback.y != 0)
        {
            player.GetComponent<FPSCharacterController>().contactDamageEnemies.Add(this);
        }
    }

    protected virtual void Start()
    {
        health.OnDeath += Die;
    }

    protected virtual void Update()
    {
        if(!isActive && Vector3.Distance(transform.position, player.transform.position) <= activationRange)
        {
            isActive = true;
        }
    }

    protected void Die(Vector3 position)
    {
        Destroy(gameObject);
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

    public virtual void ContactDamage(FPSCharacterController playerControllerScript, Health healthScript)
    {
        if (!readyToDoContactDamage)
            return;

        healthScript.ChangeHealth(-contactDamage);

        playerControllerScript.StartKnockBack(transform.position, navMeshAgent.velocity, contactDamageKnockback);

        StartCoroutine(ContactDamageCooldown());
    }

    protected IEnumerator ContactDamageCooldown()
    {
        readyToDoContactDamage = false;

        yield return new WaitForSeconds(contactDamageCoolDown);

        readyToDoContactDamage = true;

        yield return null;
    }
}
