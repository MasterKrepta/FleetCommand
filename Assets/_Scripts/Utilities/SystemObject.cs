using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SystemType
{
    WEAPON, SYSTEM
}
public abstract class SystemObject : ScriptableObject
{
    public GameObject prefab;
    public SystemType type;
    public bool IsAvail;
    public Sprite icon;
    public string Name;
    
    [TextArea(1, 25)]
    public string Desc;

    public int Size;
    public float Power;
    public float Cost;
    public float Damage;


}
