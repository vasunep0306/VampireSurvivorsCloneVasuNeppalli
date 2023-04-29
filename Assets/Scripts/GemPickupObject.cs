using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickupObject : MonoBehaviour, IPickupObject
{
    public int amount;


    /// <summary>
    /// Adds experience to the character's level when an item is picked up.
    /// </summary>
    /// <param name="character">The character who picks up the item.</param>
    public void OnPickUp(Character character)
    {
        character.level.AddExperience(amount);
    }
}
