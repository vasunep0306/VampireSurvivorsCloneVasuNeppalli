using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponsStats
{
    public int damage;
    public float timeToAttack;

    public WeaponsStats(int damage, float timeToAttack)
    {
        this.damage = damage;
        this.timeToAttack = timeToAttack;
    }

    public void Sum(WeaponsStats weaponUpgradeStats)
    {
        this.damage += weaponUpgradeStats.damage;
        this.timeToAttack += weaponUpgradeStats.timeToAttack;
    }
}

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public string Name;
    public WeaponsStats stats;
    public GameObject weaponBasePrefab;

    public List<UpgradeData> upgrades;
}
