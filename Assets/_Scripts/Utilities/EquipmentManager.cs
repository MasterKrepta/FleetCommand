using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{

    public Weapon[] AvailWeapons;
    public Equipment[] AvailEquipment;
    //public GameObject SelectedEquipment;

    public static event Action OnSelectedEquipmentChange;
    

    private GameObject _selectedEquipment;

    public GameObject SelectedEquipment
    {
        get { return _selectedEquipment; }
        set { _selectedEquipment = value; }
    }


    // Start is called before the first frame update
    void OnEnable()
    {

        //TODO load all equpment dynamically
        //equipables = Resources.LoadAll("Resources") as Weapon[];
        //equipables = Resources.LoadAll("Resources", typeof(SystemObject)); 
        
        GetAvailSystems();


        
    }

    private void GetAvailSystems()
    {
        //! Avail Equipment
        //print("Equipment: " + AvailEquipment.Length);
        foreach (var item in AvailEquipment)
        {
            if (item.IsAvail)
            {
                GameObject newImage = new GameObject();
                newImage.AddComponent<Image>().sprite = item.icon;
                newImage.transform.SetParent(this.gameObject.transform);
                newImage.name = item.Name;

                AddClickableScript(newImage);
            }
            
        }

        //! Avail Weapon
        //print("Weapons: " + AvailWeapons.Length);
        foreach (var item in AvailWeapons)
        {
            if (item.IsAvail)
            {
                GameObject newImage = new GameObject();
                newImage.AddComponent<Image>().sprite = item.icon;
                newImage.transform.SetParent(this.gameObject.transform);
                newImage.name = item.Name;

                AddClickableScript(newImage);
            }
        }
    }

    private void AddClickableScript(GameObject newImage)
    {
        Button btn = newImage.AddComponent<Button>();
        Clickable clickable =  newImage.AddComponent<Clickable>();
        
        

    }
}

