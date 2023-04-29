using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour, IPickupObject
{
    public int coinAmount;

    /// <summary>
    /// Adds the coinAmount value of this coin object to the specified character's coins collection.
    /// </summary>
    /// <param name="character">The character object to receive the coins.</param>
    public void OnPickUp(Character character)
    {
        character.coins.Add(coinAmount);
    }
}
