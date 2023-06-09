using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    [SerializeField] private float healingAmount = 50;
    [SerializeField] private GameObject parent;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<FPSCharacterController>(out FPSCharacterController playerScript))
        {
            if (playerScript.healthScript.ChangeHealth(healingAmount))
            {
                Destroy(parent);
            }
        }
    }
}
