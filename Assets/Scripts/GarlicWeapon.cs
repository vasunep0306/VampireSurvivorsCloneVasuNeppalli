using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicWeapon : WeaponBase
{

    public float attackAreaSize = 3f;
    public override void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackAreaSize);
    }
}
