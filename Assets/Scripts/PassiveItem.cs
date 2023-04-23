using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItem : MonoBehaviour
{
    public List<Item> items;
    public Character character;

    public Item testArmor;

    private void Awake()
    {
        if(character == null) { character = GetComponent<Character>(); }
    }

    private void Start()
    {
        Equip(testArmor);
    }

    public void Equip(Item itemToEquip)
    {
        if(items == null)
        {
            items = new List<Item>();
        }
        items.Add(itemToEquip);
        itemToEquip.Equip(character);
    }


    public void UnEquip(Item itemToUnEquip)
    {

    }
}
