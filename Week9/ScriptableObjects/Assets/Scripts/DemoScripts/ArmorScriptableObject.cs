using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor Data", menuName = "Armor Data", order = 2)]
public class ArmorScriptableObject : ScriptableObject
{
    public string armorName;
    public string description;
    public int damageReduction;
    public int cost;
    public Sprite armorSprite;
}
