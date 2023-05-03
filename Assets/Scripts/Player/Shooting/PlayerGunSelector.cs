using System.Collections.Generic;
using UnityEngine;

public class PlayerGunSelector : MonoBehaviour
{
    [SerializeField] private GunType gun;
    [SerializeField] private Transform gunParent;
    [SerializeField] private List<GunScriptableObject> guns;
    //[SerializeField] PlayerIK inverseKinematics;

    [Space]
    [Header("Runtime Filled")]
    public GunScriptableObject activeGun;
}
