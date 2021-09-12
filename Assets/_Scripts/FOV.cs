using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FOV : MonoBehaviour
{
    public float Radius = 45;

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
            target = rangeCheck[0].transform;


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
    }







    float FindDegree(int x, int y)
    {
        float value = Mathf.Atan2(x, y) / math.PI * 180f;
        if (value < 0) value += 360f;

        return value;

    }
}
