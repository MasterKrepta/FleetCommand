using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phaser : MonoBehaviour, IWeapon
{

    LineRenderer lr;
    public float fireSpeed;
    public float BeamTime = .5f;
    public GameObject Target;

    public bool CanFire { get; set; }
    public float rechargeTime = 1f;


    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
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
        print("phaser");
        float endTime = Time.time + BeamTime;

        StartCoroutine(StartPhaser(target));
        
    }

    IEnumerator StartPhaser(Transform target)
    {
        lr.enabled = true;
        //lr.SetPosition(0, transform.position);
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
}
