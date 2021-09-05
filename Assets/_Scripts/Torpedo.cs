using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour, IWeapon
{
    public GameObject torpedoPrefab;
    
    public float rechargeTime = 1f;

    public bool CanFire { get; set; }

    private void Start()
    {
        StartCoroutine(RechargeWeapon());
    }

    public void Fire()
    {
        Instantiate(torpedoPrefab, transform.position, transform.rotation);
        StartCoroutine(RechargeWeapon());
    }

    IEnumerator RechargeWeapon()
    {
        CanFire = false;
        yield return new WaitForSeconds(rechargeTime);
        CanFire = true;
    }
}
