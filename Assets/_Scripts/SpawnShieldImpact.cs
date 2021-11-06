using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SpawnShieldImpact : MonoBehaviour
{

    public GameObject shieldImpact;

    VisualEffect shieldImpactVFX;


    
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if (other.gameObject.tag == "Weapon")
        {
            Vector3 contactPoint = other.ClosestPoint(other.gameObject.transform.position);
            Destroy(other.gameObject);
            var impact = Instantiate(shieldImpact, transform) as GameObject;
            shieldImpactVFX = impact.GetComponent<VisualEffect>();
            
            //TODO fix this referance its probobly spelled wrong
            shieldImpactVFX.SetVector3("SphereCenter", contactPoint);

            Destroy(impact, 2);
        }
    }
}
