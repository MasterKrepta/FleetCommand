using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis(TAGS.HORIZONTAL_AXIS), Input.GetAxis(TAGS.VERTICAL_AXIS), 0);

        transform.Translate(movement * 10 * Time.deltaTime, Space.World);

    }
}
