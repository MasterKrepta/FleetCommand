using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShipSystem
{
    public IEquipable  SystemData { get; set; }
    public float MaxEnergy { get; set; }

    public bool CanEquip();
    public void UseEquipment();

    public IEnumerator EquipmentCoolDown();

}
