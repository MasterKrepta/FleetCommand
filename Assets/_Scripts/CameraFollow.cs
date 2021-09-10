using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform pivot;
    public Camera cam;
    public float Smoothing = 0.3f;
    public Vector3 velocity = Vector3.zero;
    public Vector3 offset = new Vector3(0,8,0);

    public float speedH = 2.0f;
    public float speedV = 2.0f;


    public float sensitivity = 10f;
    public float maxYAngle = 80f;
    Vector3 currentRot;
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
        FollowPlayer();

        if (Input.GetMouseButton(0))
        {
            FollowMouse();
        }
    }

    private void FollowPlayer()
    {
        transform.position = target.position + offset;
    }

    private void FollowMouse()
    {
        currentRot.x += Input.GetAxis(TAGS.MOUSE_X_AXIS) * sensitivity;
        currentRot.y += Input.GetAxis(TAGS.MOUSE_Y_AXIS) * sensitivity;
        currentRot.x = Mathf.Repeat(currentRot.x, 360);
        currentRot.y = Mathf.Clamp(currentRot.y, -maxYAngle, maxYAngle);

        pivot.rotation = Quaternion.Euler(currentRot.y, currentRot.x, 0);
        //TODO add the offest back in so the player stays centered
    }
}
