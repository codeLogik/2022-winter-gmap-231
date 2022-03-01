using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Data", menuName = "Items/EquipmentData", order = 3)]
public class EquipmentCategoryScriptableObject : ScriptableObject
{
    public WeaponScriptableObject[] weapons;
    public ArmorScriptableObject[] armor;
}
