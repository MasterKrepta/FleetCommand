using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class FOV : MonoBehaviour
{
    public float Radius = 45;
    public Text inRange;

    [Range(0, 360)]
    public float Angle;
    public LayerMask targetMask, blockingMask;

    public bool targetInArc = false;

    public Transform target;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        Collider[] rangeCheck = Physics.OverlapSphere(transform.position, Radius, targetMask);

        if (rangeCheck.Length !=  0)
        {
            target = rangeCheck[0].transform.parent.transform.parent;




            Vector3 dir = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, dir) < Angle / 2)
            {
                float dist = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dir, dist, blockingMask))
                    targetInArc = true;
                else
                    targetInArc = false;
            }
            else
            {
                targetInArc = false;
            }
        }
        else if (targetInArc)
            targetInArc = false;


        SetDebug_TargetInRange();
    }

    private void SetDebug_TargetInRange()
    {
        if (target != null)
        {
            if (targetInArc)
            {
                inRange.text = "In Arc: " + target.name;
            }
            else
            {
                inRange.text = "In Arc: ";
            }
        }
    }
      
}
