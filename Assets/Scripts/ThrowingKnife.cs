using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnife : WeaponBase
{
    public GameObject knifePrefab;
    public PlayerMove playerMove;
    public float spread = 0.5f;

    private void Awake()
    {
        if (playerMove == null) { playerMove = GetComponentInParent<PlayerMove>(); }
    }


    /// <summary>
    /// Overrides the base Attack method and throws a number of knives based on the weapon stats.
    /// </summary>
    /// <remarks>
    /// The knives are positioned with a vertical offset based on the spread value, but only if the number of attacks is greater than one.
    /// </remarks>
    public override void Attack()
    {
        for(int i = 0; i < weaponsStats.numberOfAttacks; i++)
        {
            GameObject throwKnife = Instantiate(knifePrefab);
            Vector3 newKnifePosition = transform.position;

            if (weaponsStats.numberOfAttacks > 1)
            {
                newKnifePosition.y -= (spread * weaponsStats.numberOfAttacks - 1) / 2;
                newKnifePosition.y += 1 * spread;
            }
            throwKnife.transform.position = newKnifePosition;

            ThrowingKnifeProjectile throwingKnifeProjectile = throwKnife.GetComponent<ThrowingKnifeProjectile>();
            throwingKnifeProjectile.SetDirection(playerMove.lastHorizontalVector, 0f);
            throwingKnifeProjectile.damage = weaponsStats.damage;
        }
    }
}
