using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public ShipConfiguration shipConfiguration;
    public bool available;
    public Sprite emptyImage;

    public void Start()
    {
        shipConfiguration = FindObjectOfType<ShipConfiguration>();
        Button btn = this.gameObject.AddComponent<Button>();
        btn.onClick.AddListener(OnSelected);
        //InitializeSlot();
    }

    void InitializeSlot()
    {
        GameObject newObj = new GameObject();
        newObj.AddComponent<Image>();
        //TODO only do this if we are empty
        newObj.GetComponent<Image>().sprite = emptyImage;

        RectTransform rectTran = newObj.GetComponent<RectTransform>();
        rectTran.sizeDelta = new Vector2(50, 50);




        newObj.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        newObj.transform.SetParent(transform);
        newObj.name = (transform.name);
    }


    void OnSelected()
    {
        print(this.gameObject.name);
        shipConfiguration.SelectedSlot = this.gameObject;
    }
}