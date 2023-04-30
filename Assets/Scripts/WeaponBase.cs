using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public WeaponData weaponData;

    public WeaponsStats weaponsStats;

    public float timeToAttack = 1f;
    float timer;

    public void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0f)
        {
            Attack();
            timer = timeToAttack;
        }
    }

    public abstract void Attack();

    public virtual void SetData(WeaponData wd)
    {
        weaponData = wd;
        timeToAttack = weaponData.stats.timeToAttack;

        weaponsStats = new WeaponsStats(wd.stats.damage, wd.stats.timeToAttack);
    }
}
