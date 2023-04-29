using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour, IDamagable
{

    /// <summary>
    /// Destroys this game object and checks whether any items should be dropped upon destruction.
    /// </summary>
    /// <param name="damage">The amount of damage to inflict on this game object.</param>
    public void TakeDamage(int damage)
    {
        Destroy(gameObject);
        GetComponent<DropAndDestroy>().CheckDrop();
    }
}
