using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Items/Weapon Data", order = 1)]
public class WeaponScriptableObject : ItemScriptableObject
{
    public int cost;
    public int damage;
    public DamageType damageType;
}
