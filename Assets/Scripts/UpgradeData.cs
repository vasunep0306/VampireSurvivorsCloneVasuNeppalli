using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines the types of upgrades that can be applied to weapons or items.
/// </summary>
public enum UpgradeType
{
    WeaponUpgrade, // An upgrade that improves the stats of a weapon.
    ItemUpgrade, // An upgrade that improves the stats of an item.
    WeaponUnlock, // An upgrade that unlocks a new weapon.
    ItemUnlock // An upgrade that unlocks a new item.
}


/// <summary>
/// A scriptable object that stores the data of an upgrade.
/// </summary>
[CreateAssetMenu]
public class UpgradeData : ScriptableObject
{
    public UpgradeType upgradeType; // The type of the upgrade.
    public string Name; // The name of the upgrade.
    public Sprite icon; // The icon of the upgrade.

    public WeaponData weaponData; // The data of the weapon to be upgraded or unlocked.
    public WeaponsStats weaponUpgradeStats; // The stats of the weapon to be added or improved.
}