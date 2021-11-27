using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFireTest : MonoBehaviour
{
    Launcher launcher;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        launcher = GetComponent<Launcher>();
    }

    // Update is called once per frame
    void Update()
    {
        launcher.CanFire = true;
        InvokeRepeating("TestFire", 2, 3);
    }

    void TestFire()
    {
        launcher.Fire_Targeted(target);
    }
}
