using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IDamageable))]
public class SpawnParticleSystemOnDeath : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathSystem;

    public IDamageable damageable;

    private void Awake()
    {
        damageable = GetComponent<IDamageable>();
    }

    private void OnEnable()
    {
        damageable.OnDeath += Damageable_OnDeath;
    }

    private void Damageable_OnDeath(Vector3 position)
    {
        Instantiate(deathSystem, position, Quaternion.identity);
    }
}
