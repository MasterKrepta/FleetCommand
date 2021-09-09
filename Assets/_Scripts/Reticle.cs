using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reticle : MonoBehaviour
{
    Image visual;
    public float scaleMulti = 1f;
    // Start is called before the first frame update
    void Start()
    {
        visual = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (visual.enabled == true && TargetComputer.CurrentTarget != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(TargetComputer.CurrentTarget.transform.position);
            //transform.localScale = TargetComputer.CurrentTarget.GetComponent<Renderer>().bounds.size;
        }
    }
}
