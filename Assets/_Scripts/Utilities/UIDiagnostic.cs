using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDiagnostic : MonoBehaviour
{
    public Text currentTarget, targetinRange;
    // Start is called before the first frame update
    void Start()
    {
        currentTarget = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TargetComputer.Instance.CurrentTarget == null)
            return;

        currentTarget.text = "Current Target: " + TargetComputer.Instance.CurrentTarget.name;
    }
}
