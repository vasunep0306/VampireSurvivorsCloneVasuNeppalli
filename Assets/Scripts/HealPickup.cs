using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickup : MonoBehaviour, IPickupObject
{
    public int healAmount;
    public void OnPickUp(Character character)
    {
        character.Heal(healAmount);
    }
}
