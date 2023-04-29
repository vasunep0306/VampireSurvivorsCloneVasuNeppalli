using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Defines an interface for objects that can take damage.
/// </summary>
public interface IDamagable
{

    /// <summary>
    /// Applies damage to the object.
    /// </summary>
    /// <param name="damage">The amount of damage to apply.</param>
    public void TakeDamage(int damage);
}
