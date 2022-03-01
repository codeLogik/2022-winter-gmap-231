using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemScriptableObject : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite uiIcon;
    public GameObject prefab;
}
