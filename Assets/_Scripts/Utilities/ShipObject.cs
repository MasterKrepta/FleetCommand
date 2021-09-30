using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Ship", menuName ="Scriptables/Ship")]
public class ShipObject : ScriptableObject
{
    public List<SystemObject> AvailableSystems = new List<SystemObject>();
    public List<GameObject> StoreObjets = new List<GameObject>();
    public Transform[] slots;

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

    public void ChangeSystem(SystemObject newSystem, SystemObject OldSystem, SlotGraphic slotToInstall)
    {
        Debug.Log("Change system");
        if (OldSystem != null)
        {
            //TODO return old material
          //  AvailableSystems.Add(OldSystem);
        }

        //install new into slot. 
        slotToInstall.InstalledSystem = newSystem;
        //StoreObjets.Remove(newSystem.Name);

    }

    public void UnistallSystem(SystemObject oldSystem)
    {

    }

}


