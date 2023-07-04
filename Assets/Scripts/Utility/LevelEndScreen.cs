using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndScreen : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    private void OnTriggerEnter(Collider other)
    {
        canvas.enabled = true;
    }
}
