using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipStore : MonoBehaviour
{


    //TODO this script is doing alot and can be refactored
    public static ShipStore Instance;
    [SerializeField]
    private static SystemObject _SelectedSystem;
    [SerializeField]
    private static Slot _selectedSlot;

    public ShipObject playerShip;

    public List<GameObject> storeInventory = new List<GameObject>();
    
    public static Slot SelectedSlot
    {
        get { return _selectedSlot; }
        set 
        {
            _selectedSlot = value;
            print("Set Selected Slot");
        }
    }


    private void Awake()
    {
        #region Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        #endregion

    }
    public static SystemObject SelectedSystem
    {
        get { return _SelectedSystem; }
        set 
        {
            _SelectedSystem = value;
            print("Set Selected System");
        }
    }
    
    //public Sprite emptyImage;

    private void Start()
    {
        //AssignHardpoints();
        AssignAvailableSystems();
        
    }

    private void AssignAvailableSystems()
    {
        foreach (var item in playerShip.AvailableSystems)
        {
            CreateNewSystem(item);
        }
    }

    public void CreateNewSystem(SystemObject item)
    {
        var newSystem = Instantiate(item.availIcon, transform.position, Quaternion.identity);

        newSystem.transform.SetParent(this.transform);
        newSystem.GetComponent<Image>().sprite = item.icon;
        newSystem.name = item.name;

        newSystem.AddComponent<Clickable>().data = item;
        storeInventory.Add(newSystem);
    }


    public void InstallEquipment()
    {
        if (SelectedSlot == null || SelectedSystem == null) 
            return;

        //if we have no equipment
        if (SelectedSlot.InstalledSystem == null)
        {
            playerShip.ChangeSystem(SelectedSystem, null, SelectedSlot);
        }

    }

    public void UninstallEquipment()
    {
        if (SelectedSlot.InstalledSystem == null)
            return;

        playerShip.UnistallSystem(SelectedSlot.InstalledSystem);

        //print("Uninstall: " + SelectedSlot.InstalledSystem.Name);
    }

}
