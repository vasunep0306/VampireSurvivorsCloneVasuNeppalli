using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public int armor;


    /// <summary>
    /// Equips the item to the character by adding the item's armor value to the character's armor.
    /// </summary>
    /// <param name="character">The character to equip the item to.</param>
    public void Equip(Character character)
    {
        character.armor += armor;
    }

    /// <summary>
    /// Unequips the item from the character by subtracting the item's armor value from the character's armor.
    /// </summary>
    /// <param name="character">The character to unequip the item from.</param>
    public void UnEquip(Character character)
    {
        character.armor -= armor;
    }
}
