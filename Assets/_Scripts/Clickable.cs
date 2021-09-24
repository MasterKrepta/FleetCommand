using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clickable : MonoBehaviour
{

    public EquipmentManager equipmentManager;
    public SystemObject data;
    private void Start()
    {
        equipmentManager = GetComponentInParent<EquipmentManager>();
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnSelected);
    }

    public void OnSelected()
    {
        //print(this.gameObject.name);
        equipmentManager.SelectedEquipment = this.gameObject;
    }
}
