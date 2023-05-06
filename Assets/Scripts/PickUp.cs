using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class that represents a pickable object.
/// </summary>
public class PickUp : MonoBehaviour
{

    /// <summary>
    /// Triggers when the object collides with another 2D collider.
    /// </summary>
    /// <param name="collision">The other collider involved in the collision.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character c = collision.GetComponent<Character>();
        if (c != null)
        {
            // Calls the OnPickUp method of the IPickupObject interface implemented by the object.
            GetComponent<IPickupObject>().OnPickUp(c);
            // Destroys the object after picking it up.
            Destroy(gameObject);
        }
    }
}
