using UnityEngine;
using UnityEngine.UI;

public enum EquipmentTypes
{
  
}

[CreateAssetMenu(fileName = "New Equipment", menuName = "Scriptables/Equipment")]
public class EquipmentData : ScriptableObject, IEquipable
{
    public string Name = "New Equipment";
    [SerializeField]
    private Sprite _icon;
    [SerializeField]
    private bool _isAvail;
    public EquipmentType Type = EquipmentType.HARDPOINT;
    public int MaxMass = 1;

    public float EnergyDemand { get; set; }
    public Sprite Icon { get; set; }
    public bool isAvail { get; set; }
}
