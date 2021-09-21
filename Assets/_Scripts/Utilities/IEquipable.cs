using UnityEngine;


public interface IEquipable 
{
    
    public float EnergyDemand { get; set; }
    public Sprite Icon { get; set; }

    public bool isAvail { get; set; }
}
