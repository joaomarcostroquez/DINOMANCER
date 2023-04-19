using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Old_FPSRbController : MonoBehaviour
{
    [SerializeField]
    Camera _camera;
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
        //transform.rotation = Quaternion.Euler(0, _camera.transform.rotation.eulerAngles.y, 0);
    }

    private void FixedUpdate()
    {
        _rigidbody.MoveRotation(Quaternion.Euler(0, _camera.transform.rotation.eulerAngles.y, 0));
        MoveWithForce();
    }

    private void MoveWithForce()
    {
        Vector3 movementForceDirection = new Vector3(movementInput.x, 0f, movementInput.y).normalized * movementForce;
        movementForceDirection = Quaternion.Euler(0, _camera.transform.eulerAngles.y, 0) * movementForceDirection;
        movementForceDirection = new Vector3(movementForceDirection.x, 0, movementForceDirection.z);
        _rigidbody.AddForce(movementForceDirection, ForceMode.Force);
    }
}
