using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    public bool CanFire { get; set; }
    public void Fire();
}
