using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 movementSpeed;

    private void Update()
    {
        transform.position += movementSpeed * Time.deltaTime;
    }
}
