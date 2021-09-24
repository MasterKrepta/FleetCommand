using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public ShipConfiguration shipConfiguration;


    public void Start()
    {
        shipConfiguration = FindObjectOfType<ShipConfiguration>();
        Button btn = this.gameObject.AddComponent<Button>();
        btn.onClick.AddListener(OnSelected);
    }

    void OnSelected()
    {
        print(this.gameObject.name);
        shipConfiguration.SelectedSlot = this.gameObject;
    }
}