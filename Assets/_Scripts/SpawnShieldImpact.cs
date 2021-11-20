using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SpawnShieldImpact : MonoBehaviour
{

    public GameObject shieldImpact;

    VisualEffect shieldImpactVFX;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            var impact = Instantiate(shieldImpact, transform) as GameObject;
            shieldImpactVFX = impact.GetComponent<VisualEffect>();

            
            shieldImpactVFX.SetVector3("SphereCenter", collision.contacts[0].point);

            Destroy(impact, 2);
        }
    }
}
