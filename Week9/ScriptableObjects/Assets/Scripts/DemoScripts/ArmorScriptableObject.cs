using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor Data", menuName = "Items/ArmorData", order = 2)]
public class ArmorScriptableObject : ItemScriptableObject
{
    public int damageReduction;
    public int cost;
    public Sprite armorSprite;
    public DamageType[] resistances;

    public float ReduceDamage(float damage, DamageType damageType)
    {
        foreach (var restistance in resistances)
        {
            if (restistance == damageType)
            {
                return damage - damageReduction;
            }
        }

        return damage;
    }
}
