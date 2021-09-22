using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvailableEquipment : MonoBehaviour
{

    public SystemObject[] equipables;
    // Start is called before the first frame update
    void OnEnable()
    {
        
        //TODO load all equpment dynamically

        GetAvailableEquipment();
        
    }

    private void GetAvailableEquipment()
    {
        print(equipables.Length);
    }
}
