using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour, IPickupObject
{
    public int coinAmount;
    

    public void OnPickUp(Character character)
    {
        character.coins.Add(coinAmount);
    }
}
