using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Defines an interface for objects that can be picked up by a character.
/// </summary>
public interface IPickupObject
{

    /// <summary>
    /// Action to perform when the object is picked up by a character.
    /// </summary>
    /// <param name="character">The character who picks up the object.</param>
    public void OnPickUp(Character character);
}
