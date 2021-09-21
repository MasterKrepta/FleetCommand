using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvailableEquipment : MonoBehaviour
{

    public WeaponData[] equipables;
    // Start is called before the first frame update
    void OnEnable()
    {
        
        // load all equpment dynamically
        GetAvailableEquipment();
        
    }

    private void GetAvailableEquipment()
    {
        print(equipables.Length);
    }
}
