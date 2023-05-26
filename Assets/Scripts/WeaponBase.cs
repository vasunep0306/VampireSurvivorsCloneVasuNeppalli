using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public WeaponData weaponData;

    public WeaponsStats weaponsStats;

    private Character wielder;

    float timer;
    

    public int GetDamage()
    {
        int damage = (int)(weaponData.stats.damage * wielder.damageBonus);
        return damage;
    }

    public void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0f)
        {
            Attack();
            timer = weaponsStats.timeToAttack;
        }
    }


    public void ApplyDamage(Collider2D[] colliders)
    {
        int damage = GetDamage();
        for (int i = 0; i < colliders.Length; i++)
        {
            IDamagable e = colliders[i].GetComponent<IDamagable>();
            if (e != null)
            {
                PostMessage(damage, colliders[i].transform.position);
                e.TakeDamage(damage);
            }
        }
    }

    public abstract void Attack();

    public virtual void SetData(WeaponData wd)
    {
        weaponData = wd;
        

        weaponsStats = new WeaponsStats(wd.stats.damage, wd.stats.timeToAttack, wd.stats.numberOfAttacks);
    }

    public virtual void PostMessage(int damage, Vector3 targetPosition)
    {
        MessageSystem.instance.PostMessage($"{damage}", targetPosition);
    }

    public void Upgrade(UpgradeData upgradeData)
    {
        weaponsStats.Sum(upgradeData.weaponUpgradeStats);
    }

    public void AddOwnerCharacter(Character character)
    {
        wielder = character;
    }
}
