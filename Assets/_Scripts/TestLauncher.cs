using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLauncher : MonoBehaviour
{

    public GameObject prefab, target;
    public float fireRate = 1.5f;
   
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 2, fireRate);
    }

    void Fire()
    {
        GameObject bomb = Instantiate(prefab, transform.position, Quaternion.identity);

        bomb.transform.LookAt(target.transform.position);
    }
}
