using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.Pool;

public class SpawnShieldImpact : MonoBehaviour
{

    public GameObject shieldImpact;

    VisualEffect shieldImpactVFX;

    private void OnCollisionEnter(Collision co)
    {
        if (co.gameObject.tag == "Weapon")
        { 
            var impact = Instantiate(shieldImpact, transform) as GameObject;
            shieldImpactVFX = impact.GetComponent<VisualEffect>();
            shieldImpactVFX.SetVector3("SphereCenter", co.contacts[0].point);

            Destroy(impact, 2);
        }
    }
}
