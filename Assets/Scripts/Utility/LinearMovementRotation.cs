using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovementRotation : MonoBehaviour
{
    [SerializeField] private Vector3 linearMovement, linearRotation;
    [SerializeField] private bool randomRotationDirection = false;

    [Tooltip("If 0, will use the default frame rate.")]
    [SerializeField] private int frameRate = 0;

    private float timeCounter = 0;

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
        if (frameRate == 0)
        {
            transform.Translate(linearMovement * Time.deltaTime);
            transform.Rotate(linearRotation * Time.deltaTime * rotationDirection);
        }
        else
        {
            timeCounter += Time.deltaTime;
            
            if (timeCounter >= 1f / frameRate)
            {
                transform.Translate(linearMovement * timeCounter);
                transform.Rotate(linearRotation * timeCounter * rotationDirection);
                timeCounter = 0;
            }
        }
        
    }
}
