using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDropConfig", menuName = "ItemDropConfig")]
public class ItemDropConfig : ScriptableObject
{
    public GameObject item;
    public int minAmmount = 0;
    public int maxAmmount = 2;
    public Vector3 offset = Vector3.zero;
}
