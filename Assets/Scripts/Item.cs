using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemStats
{
    public int armor;

    public void Sum(ItemStats stats)
    {
        armor += stats.armor;
    }
}

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public ItemStats stats;
    public List<UpgradeData> upgrades;

    public void Init(string Name)
    {
        this.Name = Name;
        stats = new ItemStats();
        upgrades = new List<UpgradeData>();
    }

    /// <summary>
    /// Equips the item to the character by adding the item's armor value to the character's armor.
    /// </summary>
    /// <param name="character">The character to equip the item to.</param>
    public void Equip(Character character)
    {
        character.armor += stats.armor;
    }

    /// <summary>
    /// Unequips the item from the character by subtracting the item's armor value from the character's armor.
    /// </summary>
    /// <param name="character">The character to unequip the item from.</param>
    public void UnEquip(Character character)
    {
        character.armor -= stats.armor;
    }
}
