using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    SHIELD, REACTOR, HARDPOINT, TRACTORS, SCIENCE, MINING
}

[CreateAssetMenu(fileName = "New Equipment", menuName = "slotables/Equipment")]
public class Equipment : SystemObject
{
    public EquipmentType Type = EquipmentType.HARDPOINT;
 
    

    private void Awake()
    {
        type = SystemType.WEAPON;
    }
}
