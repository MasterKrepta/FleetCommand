using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Ship", menuName ="Scriptables/Ship")]
public class ShipObject : ScriptableObject
{
    public List<SystemObject> AvailableSystems = new List<SystemObject>();
    public Transform[] slots;

    public void AssignSystem(SystemObject systemToAdd)
    {
        for (int i = 0; i < AvailableSystems.Count; i++)
        {
            if (AvailableSystems[i] != systemToAdd)
            {
                AvailableSystems.Add(systemToAdd);
            }
        }
    }


    public void ChangeSystem(SystemObject newSystem, SystemObject OldSystem, Transform slot)
    {
        //put old back into available
        //install new into slot. 

    }
    private void Awake()
    {
        //TODo load all dynamically.
        //AvailableSystems = Resources.LoadAll("Resources", typeof(SystemObject));
    }
}


