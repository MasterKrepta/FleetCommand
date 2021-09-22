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

    private Sprite _icon;
        
    public EquipmentType Type = EquipmentType.HARDPOINT;
    public int MaxMass = 1;

    public float EnergyDemand;
    public Sprite Icon;
    public bool isAvail;

    private void Awake()
    {
        type = SystemType.WEAPON;
    }
}
