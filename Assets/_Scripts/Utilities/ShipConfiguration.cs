using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipConfiguration : MonoBehaviour
{
    public Transform parent;
    public Sprite emptyImage;

    public Slot[] hardpoints;

    private void Awake()
    {
        //TODO get data from saved ship system

       AssignHardpoints();
    }

    void AssignHardpoints()
    {
        hardpoints = GetComponentsInChildren<Slot>();
        //parent = this.gameObject.transform;

        foreach (var child in hardpoints)
        {
            
            GameObject newObj = new GameObject();
            newObj.AddComponent<Image>();
            //TODO only do this if we are empty
            newObj.GetComponent<Image>().sprite = emptyImage;

            RectTransform rectTran = newObj.GetComponent<RectTransform>();
            rectTran.sizeDelta = new Vector2(50, 50);

            
            
            
            newObj.transform.position =  Camera.main.WorldToScreenPoint( child.transform.position);
            newObj.transform.SetParent(parent);
            newObj.name = (child.name);



        }
    }
}
