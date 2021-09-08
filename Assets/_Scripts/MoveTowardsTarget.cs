using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTarget : MonoBehaviour
{
    public float speed = 15f;
    public float rotSpeed = 200f;
    public float explosionRange = 1f;
    Rigidbody rb;

    Transform target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        target = TargetComputer.CurrentTarget.transform;
    }


    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (target == null || distance <= explosionRange)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 dir = target.position - rb.position;

            dir.Normalize();

            Vector3 rotAmount = Vector3.Cross(dir, transform.forward);

            rb.angularVelocity = -rotAmount * rotSpeed;

            rb.velocity = transform.forward * speed;
        }
            

        //rb.AddForce(transform.forward * speed * Time.deltaTime);
        //transform.Translate(transform.forward * speed * Time.deltaTime);

    }
}
