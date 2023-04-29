using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickup : MonoBehaviour, IPickupObject
{
    public int healAmount;

    /// <summary>
    /// Heals the character when an item is picked up.
    /// </summary>
    /// <param name="character">The character who picks up the item.</param>
    public void OnPickUp(Character character)
    {
        character.Heal(healAmount);
    }
}
