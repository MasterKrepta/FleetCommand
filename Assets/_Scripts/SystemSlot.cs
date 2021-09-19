using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSlot : MonoBehaviour, IShipSystem
{
    public IEquipable SystemData { get; set; }
    public float MaxEnergy { get; set; }

    public bool CanEquip()
    {
        return SystemData.EnergyDemand < MaxEnergy ? true :false;  //TODO add the current Energy logic
    }

    public IEnumerator EquipmentCoolDown()
    {
        throw new System.NotImplementedException();
    }

    public void UseEquipment()
    {
        throw new System.NotImplementedException();
    }
}
