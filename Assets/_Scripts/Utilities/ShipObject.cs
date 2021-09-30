using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Ship", menuName ="Scriptables/Ship")]
public class ShipObject : ScriptableObject
{
    public List<SystemObject> AvailableSystems = new List<SystemObject>();
    public List<GameObject> StoreObjects = new List<GameObject>();
    public Slot[] slots;

    //public void AssignSystem(SystemObject systemToAdd)
    //{
    //    for (int i = 0; i < AvailableSystems.Count; i++)
    //    {
    //        if (AvailableSystems[i] != systemToAdd)
    //        {
    //            AvailableSystems.Add(systemToAdd);
    //        }
    //    }
    //}

    private void Awake()
    {
        //TODo load all dynamically.
        //AvailableSystems = Resources.LoadAll("Resources", typeof(SystemObject));
    }

    public void ChangeSystem(SystemObject newSystem, SystemObject OldSystem, Slot slotToInstall)
    {
        Debug.Log("Change system");
        if (OldSystem != null)
        {
            //TODO return old material
          //  AvailableSystems.Add(OldSystem);
        }

        //install new into slot. 
        slotToInstall.InstalledSystem = newSystem;
        GameObject systemIcon = ConvertSystemToGO(newSystem);
        ShipStore.Instance.storeInventory.Remove(systemIcon);
        Destroy(systemIcon);
           
        //StoreObjets.Remove(newSystem.Name);

    }

    public void UnistallSystem(SystemObject oldSystem)
    {
        if (ShipStore.SelectedSlot == null)
            return;
        ShipStore.SelectedSlot.InstalledSystem = null; 

        ShipStore.Instance.CreateNewSystem(oldSystem);
    }


    GameObject ConvertSystemToGO(SystemObject obj)
    {
        GameObject objToRemove;
        //TODO this seems more complex then it needs to be. 
        foreach (var item in ShipStore.Instance.storeInventory)
        {
            if (obj.name == item.name)
            {
                objToRemove = item;
                return objToRemove;
            }
        }
        return null;
    }
}


