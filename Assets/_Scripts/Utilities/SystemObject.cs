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
    public Sprite icon;
    public string Name;

}
