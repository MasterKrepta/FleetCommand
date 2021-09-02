using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float thrusterSpeed = 1f;
    public float rotSpeed = 30f;

    Rigidbody rb;
    Vector3 steeringDir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        steeringDir = new Vector3(0, Input.GetAxis(TAGS.HORIZONTAL_AXIS), 0);
        transform.Rotate(steeringDir * rotSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(transform.forward * thrusterSpeed * Time.deltaTime, ForceMode.Impulse);
    }
}
