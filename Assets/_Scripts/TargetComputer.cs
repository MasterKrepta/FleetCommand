using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetComputer : MonoBehaviour
{

    public static TargetComputer Instance;

    public static GameObject CurrentTarget;
    public GameObject[] targets;
    public GameObject[] targetsInRange;


    public Image targetReticle;
    public int currentIndex = 0;
    public int targetCount;
        private void Start()
    {
        targets = GameObject.FindGameObjectsWithTag(TAGS.TARGET);
        targetsInRange = targets; //TODO For Testing Only
        
    }

    // Update is called once per frame
    void Update()
    {
        targetReticle.enabled =  (CurrentTarget == null) ? false : true;
        
            
        
        
        
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            CycleTargets(true);
        }

        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            CycleTargets(false);
        }
    }

    void CycleTargets(bool cycleLeft)
    {
        targetCount = targetsInRange.Length;
     

        if (CurrentTarget == null)
        {
            CurrentTarget = targetsInRange[0];
            currentIndex = 0;
            return;
        }
   
        {
            if (cycleLeft)
            {
                currentIndex--;
                
                if (currentIndex < 0)
                {
                    CurrentTarget = targetsInRange[2];
                    currentIndex = 2;
                    return;
                }

                CurrentTarget = targetsInRange[currentIndex];
            }
            else
            {
                currentIndex++;
                if (currentIndex == targetsInRange.Length)
                {
                    CurrentTarget = targetsInRange[0];
                    currentIndex = 0;
                    return;
                }

                CurrentTarget = targetsInRange[currentIndex];
            }
        }
    }
}
