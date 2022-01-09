using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipMovement : MonoBehaviour
{
    public float thrusterSpeed = 1f;
    public Slider thrusterSlider;

    public float climbSpeed = 10f;
    public float turnSpeed = 30f;
    public float bankSpeed = 5f;

    Rigidbody rb;
    Vector3 steering;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        steering = new Vector3(Input.GetAxis(TAGS.VERTICAL_AXIS) * climbSpeed, 
                                Input.GetAxis(TAGS.HORIZONTAL_AXIS) * turnSpeed, 
                                Input.GetAxis(TAGS.BANK_AXIS) * bankSpeed);
        
        transform.Rotate(steering * Time.deltaTime);
        GetThrottle();
    }

    private void GetThrottle()
    {
        if (Input.GetKeyDown(KeyCode.Period) && thrusterSpeed < 4) 
        {
            thrusterSpeed++;
        }

        if (Input.GetKeyDown(KeyCode.Comma) && thrusterSpeed > -1)
        {
            thrusterSpeed--;
        }
            
        thrusterSlider.value = thrusterSpeed;
    }

    public void SetThrottle()
    {
        //todo make this work with the camera control systems
        thrusterSpeed = thrusterSlider.value;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.AddForce(transform.forward * thrusterSpeed * Time.deltaTime, ForceMode.Impulse);

        transform.Translate(transform.forward * thrusterSpeed * Time.deltaTime, Space.World);
    }
}
