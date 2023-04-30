using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponsStats
{
    public int damage;
    public float timeToAttack;
}

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public string Name;
    public WeaponsStats stats;
    public GameObject weaponBasePrefab;
}
