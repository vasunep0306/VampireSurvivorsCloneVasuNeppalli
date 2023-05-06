using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public WeaponData weaponData;

    public WeaponsStats weaponsStats;

    float timer;

    public void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0f)
        {
            Attack();
            timer = weaponsStats.timeToAttack;
        }
    }

    public abstract void Attack();

    public virtual void SetData(WeaponData wd)
    {
        weaponData = wd;
        

        weaponsStats = new WeaponsStats(wd.stats.damage, wd.stats.timeToAttack);
    }

    public virtual void PostMessage(int damage, Vector3 targetPosition)
    {
        MessageSystem.instance.PostMessage($"{damage}", targetPosition);
    }

    public void Upgrade(UpgradeData upgradeData)
    {
        weaponsStats.Sum(upgradeData.weaponUpgradeStats);
    }
}
