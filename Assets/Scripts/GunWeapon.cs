using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : WeaponBase
{
    public GameObject bulletPrefab;

    public override void Attack()
    {
        UpdateVectorOfAttack();
        for (int i = 0; i < weaponsStats.numberOfAttacks; i++)
        {
            GameObject throwKnife = Instantiate(bulletPrefab);
            Vector3 newKnifePosition = transform.position;

            throwKnife.transform.position = newKnifePosition;

            ThrowingKnifeProjectile throwingKnifeProjectile = throwKnife.GetComponent<ThrowingKnifeProjectile>();
            throwingKnifeProjectile.SetDirection(vectorOfAttack.x, vectorOfAttack.y);
            throwingKnifeProjectile.damage = GetDamage();
        }
    }
}
