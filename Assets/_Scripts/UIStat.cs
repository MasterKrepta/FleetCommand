using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStat : MonoBehaviour
{
    public EquipmentManager equipmentManager;

    [SerializeField]
    private GameObject _selected;

    public Sprite selIconGraphic;
    public Image selIcon;
    public Text selName, selSize, selDesc, selDmg, selPwr, selCst;
    

    private void OnEnable()
    {
        equipmentManager = FindObjectOfType<EquipmentManager>();
        equipmentManager.OnSelectedEquipmentChange += GetNewSelected;
    }

    private void OnDisable()
    {
        equipmentManager.OnSelectedEquipmentChange -= GetNewSelected;
    }


    public GameObject Selected
    {
        get { return _selected; }
        set { 
            _selected = value;
            SetupSelected();
        }
    }

    private void SetupSelected()
    {
        SystemObject data = Selected.GetComponent<Clickable>().data;
        selIconGraphic = data.icon;
        selIcon.sprite = selIconGraphic;
        selName.text = _selected.name;
        selDesc.text = $"Desc:  { data.Desc.ToString()}";
        selSize.text = $"Size:  {data.Size.ToString()}";
        selCst.text = $"Cost:   {data.Cost.ToString()}";
        selDmg.text = $"Damage: {data.Damage.ToString()}";
        selPwr.text = $"Power:  {data.Power.ToString()}";
    }

    void GetNewSelected()
    {
        Selected = equipmentManager.SelectedEquipment;
    }
}
