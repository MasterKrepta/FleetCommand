using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBomb : MonoBehaviour
{
    public Gradient[] possibleColors;
    public Gradient assignedColor;
    public Transform target;

    public float explosionRange = .5f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;

        int rand = Random.Range(0, possibleColors.Length);
        assignedColor = possibleColors[rand];
       // GetComponent<Material>().color = assignedColor.colorKeys[0].color;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (target == null || distance <= explosionRange)
        {
            target.GetComponent<IDamageable>().TakeDamage(1);
            Destroy(gameObject);
        }
    }

}
