using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float thrusterSpeed = 1f;
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.AddForce(transform.forward * thrusterSpeed * Time.deltaTime, ForceMode.Impulse);

        transform.Translate(transform.forward * thrusterSpeed * Time.deltaTime, Space.World);
    }
}
