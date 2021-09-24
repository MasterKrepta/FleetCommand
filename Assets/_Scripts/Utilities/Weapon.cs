using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    ENERGY, PHASER, BLASTER, PHOTON, PLASMA, ION, MAGNETIC, TOXIC
}

[CreateAssetMenu(fileName ="New Weapon", menuName = "slotables/Weapons")]
public class Weapon : SystemObject
{
    public WeaponType Type = WeaponType.ENERGY;

    private void Awake()
    {
        type = SystemType.WEAPON;
    }
}
