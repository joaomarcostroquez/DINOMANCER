using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovementRotation : MonoBehaviour
{
    [SerializeField] private Vector3 linearMovement, linearRotation;
    [SerializeField] private bool randomRotationDirection = false;

    private int rotationDirection = 1;

    private void Start()
    {
        if (randomRotationDirection)
        {
            if(Random.value > 0.5f)
            {
                rotationDirection = -1;
            }
        }
    }

    private void Update()
    {
        transform.Translate(linearMovement * Time.deltaTime);
        transform.Rotate(linearRotation * Time.deltaTime * rotationDirection);
    }
}
