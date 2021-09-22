using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvailableEquipment : MonoBehaviour
{

    public Weapon[] equipables;
    
    // Start is called before the first frame update
    void OnEnable()
    {

        //TODO load all equpment dynamically
        equipables = Resources.LoadAll("Resources") as Weapon[];
        //equipables = Resources.LoadAll("Resources", typeof(SystemObject)); 
        GetAvailableEquipment();
        
    }

    private void GetAvailableEquipment()
    {
        print(equipables.Length);
        foreach (var item in equipables)
        {
            if (item.IsAvail)
            {
                GameObject newImage = new GameObject();
                newImage.AddComponent<Image>().sprite = item.icon;
                newImage.transform.SetParent(this.gameObject.transform);
            }
        }
    }
}
