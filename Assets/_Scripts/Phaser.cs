using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phaser : MonoBehaviour, IWeapon
{
    LineRenderer lr;
    public float fireSpeed;
    public float BeamTime = .5f;
    public float dmg;
    public float beamLength = 200f;
    //public GameObject Target;

    public bool CanFire { get; set; }
    
    public float rechargeTime = 1f;

    FOV parentFov;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        parentFov = GetComponentInParent<FOV>();
        lr.enabled = false;
    }

    private void Start()
    {
        StartCoroutine(RechargeWeapon());
    }

    public void Fire()
    {

    }

    private void Update()
    {
        //Target = TargetComputer.Instance.CurrentTarget; //TODO why didnt i need this before

        lr.SetPosition(0, transform.position);
    }
    public void Fire_Targeted(Transform target)
    {
        float endTime = Time.time + BeamTime;

        if (TargetComputer.Instance.CurrentTarget != null)
        {
            StartCoroutine(StartPhaser(TargetComputer.Instance.CurrentTarget.transform));
        }
    }

    IEnumerator StartPhaser(Transform target)
    {
        //TODO procedure. 
        //1: Get raycast from origin to target location.
        //2: On hit.position set end point of Line renderer
        //3: call shield event and apply damage

        lr.enabled = true;

        RaycastHit hit;

        if(Physics.Raycast(transform.position, target.transform.position, out hit, beamLength))
        {
            lr.SetPosition(1, target.transform.position);
            IDamageable hitTarget = hit.transform.GetComponent<IDamageable>();
            
            if (hitTarget != null)
            {

                hitTarget.TakeDamage(dmg, hit.collider);
            }
        }
 
        yield return new WaitForSeconds(BeamTime);

        //TODO make the end of the beam slerp to the target

        lr.enabled = false;
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
        //print($"Current {TargetComputer.Instance.CurrentTarget.name}");

        //print($"in arc: {parentFov.target.name}");

        if (TargetComputer.Instance.CurrentTarget.name == parentFov.target.name && parentFov.targetInArc)
        {
            return true;
        }
        //return parentFov.targetInArc;
        return false;

    }

    void OnDrawGizmosSelected()
    {
        Debug.DrawRay(transform.position, TargetComputer.Instance.CurrentTarget.transform.position, Color.yellow, beamLength);
    }
}
