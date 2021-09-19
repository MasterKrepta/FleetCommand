using UnityEngine;
using UnityEngine.UI;

public enum EquipmentType
{
    SHIELD, REACTOR, HARDPOINT, TRACTORS, SCIENCE, MINING
}

[CreateAssetMenu(fileName = "New Equipment", menuName = "Scriptables/Equipment")]
public class EquipmentData : ScriptableObject, IEquipable
{
    public string Name = "New Equipment";
    public Image Icon;
    public EquipmentType Type = EquipmentType.HARDPOINT;
    public int MaxMass = 1;

    float IEquipable.EnergyDemand { get; set; }
}
