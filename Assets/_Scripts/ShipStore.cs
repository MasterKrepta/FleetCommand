using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipStore : MonoBehaviour
{

    private static SystemObject _SelectedSystem;
    private static SlotGraphic _selectedSlot;

    public ShipObject playerShip;
    public static SlotGraphic SelectedSlot
    {
        get { return _selectedSlot; }
        set 
        {
            _selectedSlot = value;
            print("Set Selected Slot");
        }
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
    public GameObject AvailIcon;
    public Sprite emptyImage;

    private void Start()
    {
        AssignHardpoints();
        AssignAvailableSystems();
        
    }

    private void AssignAvailableSystems()
    {
        foreach (var item in playerShip.AvailableSystems)
        {
            var newSystem = Instantiate(AvailIcon, transform.position, Quaternion.identity);

            newSystem.transform.SetParent(this.transform);
            newSystem.GetComponent<Image>().sprite = item.icon;
            newSystem.name = item.name;

            newSystem.AddComponent<Clickable>().data = item;
        }
    }

    void AssignHardpoints()
    {
        foreach (var child in playerShip.slots)
        {

            GameObject newObj = new GameObject();
            newObj.AddComponent<Image>();
            //TODO only do this if we are empty
            newObj.GetComponent<Image>().sprite = emptyImage;

            RectTransform rectTran = newObj.GetComponent<RectTransform>();
            rectTran.sizeDelta = new Vector2(50, 50);

            newObj.transform.position = Camera.main.WorldToScreenPoint(child.transform.position);
            newObj.transform.SetParent(transform.parent);
            newObj.name = (child.name);

            newObj.AddComponent<SlotGraphic>().slot = child.gameObject;


        }
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
