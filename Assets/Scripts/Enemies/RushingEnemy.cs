using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RushingEnemy : Enemy
{
    [SerializeField] private float rushAcceleration = 50f;

    private Rigidbody _rigidbody;
    private bool isRushing = false;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
    }

    private void Update()
    {
        if (!isRushing)
        {
            if (MoveUntilPlayerInRangeAndOnSight())
                StartRush();
        } 
    }

    private void FixedUpdate()
    {
        if (isRushing)
        {
            RushAttack();
        }
    }

    private void StartRush()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.enabled = false;

        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        _rigidbody.isKinematic = false;
        isRushing = true;
    }

    private void RushAttack()
    {
        _rigidbody.AddForce(transform.forward * rushAcceleration, ForceMode.Acceleration);
    }
}
