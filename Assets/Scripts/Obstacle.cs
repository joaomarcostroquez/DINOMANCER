using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] protected float contactDamage = 10f;
    [SerializeField] protected Vector2 contactDamageKnockback = Vector2.one;
    [SerializeField] protected float contactDamageCoolDown = 1f;

    protected bool readyToDoContactDamage = true;

    public void ContactDamage(FPSCharacterController playerControllerScript)
    {
        if (!readyToDoContactDamage)
            return;

        playerControllerScript.healthScript.ChangeHealth(-contactDamage);

        playerControllerScript.StartKnockBack(contactDamageKnockback);

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
