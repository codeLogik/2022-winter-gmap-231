using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Weapon Data", order = 1)]
public class WeaponScriptableObject : ScriptableObject
{
    public string weaponName;
    public string description;
    public int cost;
    public int damage;
    public Sprite weaponSprite;
}
