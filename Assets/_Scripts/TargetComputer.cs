using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetComputer : MonoBehaviour
{

    public static TargetComputer Instance;

    public  GameObject CurrentTarget;
    public List<GameObject> targets;
    public  List<GameObject> targetsInRange;


    public Image targetReticle;
    public int currentIndex = 0;
    public int targetCount;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        var tempTargets = GameObject.FindGameObjectsWithTag(TAGS.TARGET);

        foreach (var t in tempTargets)
        {
            targets.Add(t);
        }
        targetCount = targets.Count;
        targetsInRange = targets; //TODO For Testing Only
        
    }

    // Update is called once per frame
    void Update()
    {
        targetReticle.enabled =  (CurrentTarget == null) ? false : true;
        
            
        //TODO handle Range mechanics to assign targets
        
        
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
        targetCount = targetsInRange.Count;
     

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
                if (currentIndex == targetsInRange.Count)
                {
                    CurrentTarget = targetsInRange[0];
                    currentIndex = 0;
                    return;
                }
                //todo bugs when targets destroyed
                CurrentTarget = targetsInRange[currentIndex];
            }
        }
    }

    public  void RemoveTarget(GameObject t)
    {
        targets.Remove(t);
    }
}
