using UnityEngine;
using UnityEngine.UI;

public enum WeaponType
{
    ENERGY, PHASER, BLASTER, PHOTON, PLASMA, ION, MAGNETIC, TOXIC
}

[CreateAssetMenu(fileName ="New Weapon", menuName ="Scriptables/Weapon")]
public class WeaponData : ScriptableObject, IEquipable
{
    public string Name = "New Weapon";

    [SerializeField]
    private Sprite _icon;
    [SerializeField]
    private bool _isAvail;


    public WeaponType Type = WeaponType.ENERGY;
    


    public float Damage = 1f;
    public float FireRate = 2f;

    public float EnergyDemand { get; set; }
    public Sprite Icon { get; set; }
    public bool isAvail { get; set; }
}
