using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponsStats
{
    public int damage;
    public float timeToAttack;
    public int numberOfAttacks;

    public WeaponsStats(int damage, float timeToAttack, int numberOfAttacks)
    {
        this.damage = damage;
        this.timeToAttack = timeToAttack;
        this.numberOfAttacks = numberOfAttacks;
    }

    /// <summary>
    /// Adds the values of the weapon upgrade stats to the current weapon stats.
    /// </summary>
    /// <param name="weaponUpgradeStats">The weapon upgrade stats to be added.</param>
    public void Sum(WeaponsStats weaponUpgradeStats)
    {
        this.damage += weaponUpgradeStats.damage;
        this.timeToAttack += weaponUpgradeStats.timeToAttack;
        this.numberOfAttacks += weaponUpgradeStats.numberOfAttacks;
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
