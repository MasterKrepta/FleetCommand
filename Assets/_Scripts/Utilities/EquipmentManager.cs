using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{

    public Weapon[] AvailWeapons;
    public Equipment[] AvailEquipment;
    public GameObject AssignBtn;
    //public GameObject SelectedEquipment;
    ShipConfiguration ship;

    public  event Action OnSelectedEquipmentChange;
    
    [SerializeField]
    private GameObject _selectedEquipment;

    public GameObject SelectedEquipment
    {
        get { return _selectedEquipment; }
        set { 
            _selectedEquipment = value;
            OnSelectedEquipmentChange();
        }
    }


    // Start is called before the first frame update
    void OnEnable()
    {

        //TODO load all equpment dynamically
        //equipables = Resources.LoadAll("Resources") as Weapon[];
        //equipables = Resources.LoadAll("Resources", typeof(SystemObject)); 
        
        GetAvailSystems();
        ship = FindObjectOfType<ShipConfiguration>();


        
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

                AddClickableScript(newImage, item);
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

                AddClickableScript(newImage, item);
            }
        }
    }

    private void AddClickableScript(GameObject newImage, SystemObject slot)
    {
        Button btn = newImage.AddComponent<Button>();
        Clickable clickable =  newImage.AddComponent<Clickable>();
        clickable.data = slot;
        
        

    }

    public void AssignEquipmentToSlot()
    {
        print("selected");
        GameObject parentSlot = GameObject.Find(ship.SelectedSlot.name);

        GameObject equipmentGO =  MakeGameObjectFromEquipmentData();
        //Create prefab.
        ship.SelectedSlot.GetComponent<Image>().sprite = SelectedEquipment.GetComponent<Clickable>().data.icon;
        //Parent it to ship variable. 

        equipmentGO.transform.parent = parentSlot.transform;
        equipmentGO.transform.position = Vector3.zero;
        equipmentGO.AddComponent<Clickable>().data = SelectedEquipment.GetComponent<Clickable>().data;

        
        //AssignBtn.SetActive(false);
        RemoveAvailalbeEquipiment(SelectedEquipment);

        //TODO remove image from avaiialbe equipment (and reverse)

    }

    public void UnassignEquipment()
    {
        //TODO re add the equipment to the list based on data type. 
        //var data = SelectedEquipment.GetComponent<Clickable>().data;

        //GameObject newImage = new GameObject();
        //newImage.AddComponent<Image>().sprite = item.icon;
        //newImage.transform.SetParent(this.gameObject.transform);
        //newImage.name = item.Name;

        //AddClickableScript(newImage, item);
    }
    private void RemoveAvailalbeEquipiment(GameObject selectedEquipment)
    {
       // Destroy(ship.SelectedSlot);
        Destroy(selectedEquipment);
    }

    void ReturnEquipmentToAvailable(GameObject equipmentToReturn)
    {
        //todo return equipment
    }

    private GameObject MakeGameObjectFromEquipmentData()
    {
        var data = SelectedEquipment.GetComponent<Clickable>().data;
        GameObject newGO = new GameObject();
        newGO.name = data.name;
        return newGO;
    }

    
}

