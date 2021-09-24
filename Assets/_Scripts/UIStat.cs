using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStat : MonoBehaviour
{
    private GameObject _selected;

    public Sprite selIconGraphic;
    public Image selIcon;
    public Text selName, selDmg, selPwr, selCst;
    
    public float dmg, pwr, cst = 1f;


        
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
        selIconGraphic = Selected.GetComponent<SystemObject>().icon;
        selIcon.sprite = selIconGraphic;
        selName.text = _selected.name;
        selCst.text = cst.ToString();
        selDmg.text = dmg.ToString();
        selPwr.text = pwr.ToString() ;
    }

    void GetNewSelected()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        selIcon = GetComponent<Image>();
        _selected = FindObjectOfType<EquipmentManager>().SelectedEquipment;
        //TODO set up event system OnChangeSelectedEquipment
    }

    
}
