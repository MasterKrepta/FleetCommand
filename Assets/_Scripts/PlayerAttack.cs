using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public IWeapon[] weaponPoints;

    private void Awake()
    {
        weaponPoints = GetComponentsInChildren<IWeapon>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            foreach (var weapon in weaponPoints)
            {
                if (weapon.CanFire && TargetComputer.Instance.CurrentTarget != null) //TODO firing arcs mechanics not designed. 
                {
                    weapon.Fire_Targeted(TargetComputer.Instance.CurrentTarget.transform);
                    //weapon.Fire();
                }
                
            }
        }
    }
}
