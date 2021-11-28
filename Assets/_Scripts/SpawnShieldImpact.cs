using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.Pool;
using System;

public class SpawnShieldImpact : MonoBehaviour
{
    public Action<Collision> OnImpact;
    public GameObject shieldImpact;

    VisualEffect shieldImpactVFX;

    private void OnEnable()
    {
        OnImpact += SpawnEffect;
    }

    private void OnDisable()
    {
        OnImpact -= SpawnEffect;
    }

    private void OnCollisionEnter(Collision collision)
    {
        SpawnEffect(collision);
    }
    //private void OnCollisionEnter(Collision co)
    //{
    //    if (co.gameObject.tag == "Weapon")
    //    {
    //        Gradient impactColor = co.gameObject.GetComponent<TestBomb>().assignedColor;
    //        Destroy(co.gameObject);

    //        var impact = Instantiate(shieldImpact, transform) as GameObject;
    //        shieldImpactVFX = impact.GetComponent<VisualEffect>();
    //        shieldImpactVFX.SetVector3("SphereCenter", co.contacts[0].point);
    //        shieldImpactVFX.SetGradient("ImpactColor", impactColor);
    //        Destroy(impact, 2);
    //    }
    //}

    void SpawnEffect(Collision co)
    {

        if (co.gameObject.tag == "Weapon")

        {
            Debug.Log(co.gameObject.name.ToString());
            // Gradient impactColor = co.gameObject.GetComponent<TestBomb>().assignedColor;
            

            var impact = Instantiate(shieldImpact, transform) as GameObject;
            shieldImpactVFX = impact.GetComponent<VisualEffect>();
            shieldImpactVFX.SetVector3("SphereCenter", co.contacts[0].point);
            //shieldImpactVFX.SetGradient("ImpactColor", impactColor);
            Destroy(co.gameObject);
            Destroy(impact, 2f);
        }
    }
}
