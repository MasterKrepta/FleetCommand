using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float Smoothing = 0.3f;
    public Vector3 velocity = Vector3.zero;
    public Vector3 offset = new Vector3(0,5,-10);
    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag(TAGS.PLAYER).transform;
        }   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.TransformPoint(offset);

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, Smoothing);


    }
}
