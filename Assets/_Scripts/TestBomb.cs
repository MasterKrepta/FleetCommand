using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBomb : MonoBehaviour
{
    public Gradient[] possibleColors;
    public Gradient assignedColor;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, possibleColors.Length);
        assignedColor = possibleColors[rand];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
