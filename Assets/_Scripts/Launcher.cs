using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour, IWeapon
{
    public GameObject torpedoPrefab;
    
    public float rechargeTime = 1f;

    public bool CanFire { get; set; }
    FOV parentFov;

    private void Awake()
    {
        parentFov = GetComponentInParent<FOV>();
    }
    private void Start()
    {
        StartCoroutine(RechargeWeapon());
    }

    public void Fire()
    {
        Instantiate(torpedoPrefab, transform.position, transform.rotation);
        StartCoroutine(RechargeWeapon());
    }

    public void Fire_Targeted(Transform target)
    {
        transform.LookAt(target);
        GameObject go =  Instantiate(torpedoPrefab, transform.position, transform.rotation);
        
        StartCoroutine(RechargeWeapon());
    }

    IEnumerator RechargeWeapon()
    {
        CanFire = false;
        yield return new WaitForSeconds(rechargeTime);
        CanFire = true;
    }

    public bool TargetInRange()
    {
        print($"Current {TargetComputer.Instance.CurrentTarget.name} || in arc: {parentFov.target.name}");

        if (TargetComputer.Instance.CurrentTarget.name == parentFov.target.name && parentFov.targetInArc)
        {
            return true;
        }
        //return parentFov.targetInArc;
        return false;
    }
}
