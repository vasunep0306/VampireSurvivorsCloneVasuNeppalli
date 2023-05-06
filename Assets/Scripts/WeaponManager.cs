using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Transform weaponObjectsContainer;
    public WeaponData startingWeapon;

    List<WeaponBase> weapons;

    private void Awake()
    {
        weapons = new List<WeaponBase>();
    }

    private void Start()
    {
        AddWeapon(startingWeapon);
    }



    /// <summary>
    /// Instantiates a weapon game object from a weapon data and adds it to the weapon objects container and the weapons list.
    /// Also adds the weapon data's upgrades to the level's list of all available upgrades if the level component exists.
    /// </summary>
    /// <param name="weaponData">The weapon data to instantiate the weapon from.</param>
    public void AddWeapon(WeaponData weaponData)
    {
        GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefab, weaponObjectsContainer);
        WeaponBase weaponBase = weaponGameObject.GetComponent<WeaponBase>();
        weaponBase.SetData(weaponData);

        weapons.Add(weaponBase);

        Level level =  GetComponent<Level>();
        if(level != null)
        {
            level.AddUpgradableToListOfAllAvailableUpgrades(weaponData.upgrades);
        }
    }

    /// <summary>
    /// Upgrades a weapon with the given upgrade data if it exists in the weapons list.
    /// </summary>
    /// <param name="upgradeData">The upgrade data to apply to the weapon.</param>
    public void UpgradeWeapon(UpgradeData upgradeData)
    {
        WeaponBase weaponToUpgrade = weapons.Find(wd => wd.weaponData == upgradeData.weaponData);
        weaponToUpgrade.Upgrade(upgradeData);
    }
}
