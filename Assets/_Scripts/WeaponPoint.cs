using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPoint : MonoBehaviour, IEquipmentPoint
{
    public GameObject WeaponPrefab;
    public void UseEquipment()
    {
        Instantiate(WeaponPrefab, transform.position, transform.rotation);
    }

    
}
