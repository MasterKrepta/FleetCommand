using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipStore : MonoBehaviour
{
    public ShipObject playerShip;
    public static SystemObject SelectedSystem;
    public GameObject AvailIcon;

    private void Start()
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

}
