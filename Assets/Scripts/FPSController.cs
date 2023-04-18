using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField]
    private float movementForce = 5;

    private Vector2 movementInput;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        movementInput.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        MoveWithForce();
    }

    private void MoveWithForce()
    {
        Vector3 movementForceDirection = new Vector3(movementInput.x, 0f, movementInput.y).normalized * movementForce;
        _rigidbody.AddForce(movementForceDirection, ForceMode.Force);
    }
}
