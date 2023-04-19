using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovementBetweenPoints : MonoBehaviour
{
    [SerializeField]
    private Vector3[] targetPoints;
    [SerializeField]
    private float movementSpeed = 1;
    [SerializeField]
    private Vector3 rotationSpeed;

    private int currentTarget = 0;

    private void Start()
    {
        for(int i = 0; i < targetPoints.Length; i++)
        {
            if (i + 1 < targetPoints.Length)
                Debug.DrawLine(targetPoints[i], targetPoints[i + 1], Color.red, float.PositiveInfinity);
            else
                Debug.DrawLine(targetPoints[i], targetPoints[0], Color.red, float.PositiveInfinity);
        }
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, targetPoints[currentTarget]) <= 0.05f)
        {
            if (currentTarget + 1 < targetPoints.Length)
                currentTarget++;
            else
                currentTarget = 0;
        }

        transform.Translate((targetPoints[currentTarget] - transform.position).normalized * movementSpeed * Time.deltaTime, Space.World);

        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
