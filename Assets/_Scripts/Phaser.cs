using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phaser : MonoBehaviour, IWeapon
{

    LineRenderer lr;
    public float fireSpeed;
    public float BeamTime = .5f;
    public float dmg;
    public GameObject Target;

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
        lr.SetPosition(0, transform.position);
    }
    public void Fire_Targeted(Transform target)
    {
        float endTime = Time.time + BeamTime;

        if (TargetComputer.Instance.CurrentTarget != null)
        {
            StartCoroutine(StartPhaser(target));
        }
    }

    IEnumerator StartPhaser(Transform target)
    {
        lr.enabled = true;
        //lr.SetPosition(0, transform.position);
        target.GetComponent<IDamageable>().TakeDamage(dmg);
        lr.SetPosition(1, target.transform.position);
        yield return new WaitForSeconds(BeamTime);

        //lr.SetPosition(0, transform.position);
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
        if (parentFov.target == TargetComputer.Instance.CurrentTarget)
        {
            return parentFov.targetInArc;
        }
        else return false;
        
    }
}
