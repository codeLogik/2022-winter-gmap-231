using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Data", menuName = "Equipment Data", order = 3)]
public class EquipmentScriptableObject : ScriptableObject
{
    public WeaponScriptableObject[] weapons;
    public ArmorScriptableObject[] armor;
}
