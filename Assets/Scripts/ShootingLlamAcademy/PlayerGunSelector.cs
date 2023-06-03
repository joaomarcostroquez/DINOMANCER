using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerGunSelector : MonoBehaviour
{
    [SerializeField] private GunType _gunType;
    [SerializeField] private Transform gunParent;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private List<GunScriptableObject> guns;
    //[SerializeField] PlayerIK inverseKinematics;

    [Space]
    [Header("Runtime Filled")]
    public GunScriptableObject activeGun;

    private void Start()
    {
        GunScriptableObject gun = guns.Find(gun => gun.type == _gunType);

        if(gun == null)
        {
            Debug.LogError($"No GunScriptableObject found for GunType: {gun}");
            return;
        }

        activeGun = gun;
        gun.Spawn(gunParent, this, playerCamera);
    }
}
