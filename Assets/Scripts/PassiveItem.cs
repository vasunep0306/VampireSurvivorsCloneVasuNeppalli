using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItem : MonoBehaviour
{
    public List<Item> items;
    public Character character;

    //public Item testArmor;

    private void Awake()
    {
        if(character == null) { character = GetComponent<Character>(); }
    }

    private void Start()
    {
        //Equip(testArmor);
    }


    /// <summary>
    /// Equips an item to the character and adds it to the list of items.
    /// </summary>
    /// <param name="itemToEquip">The item to be equipped.</param>
    public void Equip(Item itemToEquip)
    {
        if(items == null)
        {
            items = new List<Item>();
        }

        // Creates a new item instance with the same name and stats as the item to equip.
        Item newItemInstance = ScriptableObject.CreateInstance<Item>();
        newItemInstance.Init(itemToEquip.Name);
        newItemInstance.stats.Sum(itemToEquip.stats);

        // Adds the new item instance to the items list and equips it to the character.
        items.Add(newItemInstance);
        newItemInstance.Equip(character);
    }

    /// <summary>
    /// Upgrades an item in the items list by adding the stats from the upgrade data object, and re-equips it to the character
    /// </summary>
    /// <param name="upgradeData">The upgrade data object that contains the item name and the stats to be added.</param>
    public void upgradeItem(UpgradeData upgradeData)
    {
        Item itemToUpgrade = items.Find(id => id.Name == upgradeData.item.Name);
        itemToUpgrade.UnEquip(character);
        itemToUpgrade.stats.Sum(upgradeData.itemStats);
        itemToUpgrade.Equip(character);
    }

    public void UnEquip(Item itemToUnEquip)
    {

    }

   
}
