using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public ShipConfiguration shipConfiguration;
    public GameObject slotParent;
    public SystemObject InstalledSystem;
    public GameObject SlotIcon;
    public bool available;
    
    public void Start()
    {
        //shipConfiguration = FindObjectOfType<ShipConfiguration>();
        //Button btn = this.gameObject.AddComponent<Button>();
        
        Button btn = SlotIcon.GetComponent<Button>();
        btn.onClick.AddListener(OnSelected);
        InitializeSlot();
    }

    void InitializeSlot()
    {
        GameObject newObj = Instantiate(SlotIcon, Vector3.zero, Quaternion.identity, slotParent.transform);
        
        newObj.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        RectTransform rectTran = newObj.GetComponent<RectTransform>();
        rectTran.sizeDelta = new Vector2(50, 50);

        newObj.name = (transform.name);

        newObj.GetComponent<Button>().onClick.AddListener(OnSelected);
        
    }


    void OnSelected()
    {
        
        ShipStore.SelectedSlot = this;
        print("Slot: " + this.name);
        //shipConfiguration.SelectedSlot = this.gameObject;
    }
}