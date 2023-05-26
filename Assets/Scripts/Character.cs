using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public DataContainer dataContainer;
    // Declare variables for maximum health, current health and health bar UI element
    public int maxHp = 1000;
    public int currentHp = 1000;
    public StatusBar hpBar;

    public int armor = 0;

    // Declare variables for level and coins objects
    public Level level;
    public Coins coins;

    // Declare variables for health regeneration rate per second and timer for regeneration
    public float hpRegenerationRate = 1f;
    public float hpRegenerationTimer;

    public float damageBonus;


    public GameOver gameOver;

    private bool isDead = false;

    private void Start()
    {
        ApplyPersistantUpgrades();
        hpBar.SetState(currentHp, maxHp);
        coins.Add(0);
    }

    private void ApplyPersistantUpgrades()
    {
        // Get the upgrade level for health from the data container and increase the maximum and current health accordingly
        int hpUpgradeLevel = dataContainer.GetUpgradeLevel(PlayerPersistentUpgrades.HP);
        maxHp += maxHp / 10 * hpUpgradeLevel;
        currentHp += maxHp;

        // Get the upgrade level for damage from the data container and calculate the damage bonus factor
        int damageUpgradeLevel = dataContainer.GetUpgradeLevel(PlayerPersistentUpgrades.DAMAGE);
        damageBonus = 1f + 0.1f * damageUpgradeLevel;
    }

    private void Update()
    {
        hpRegenerationTimer += Time.deltaTime * hpRegenerationRate;
        // If the regeneration timer is greater than one second, heal one point of health and reduce the timer by one second
        if (hpRegenerationTimer > 1f)
        {
            Heal(1);
            hpRegenerationTimer -= 1f;
        }
    }

    /// <summary>
    /// Reduces the character's current health points by the specified amount of damage, after applying armor mitigation.
    /// If the character's current health points drop to or below zero, the game over screen is displayed and isDead is set to true.
    /// Updates the character's health bar UI to reflect the new health value.
    /// </summary>
    /// <param name="damage">The amount of damage to be applied to the character's health points.</param>
    public void TakeDamage(int damage)
    {
        if(isDead) { return; }
        ApplyArmor(ref damage);
        currentHp -= damage;

        if(currentHp <= 0)
        {
            gameOver.CharacterGameOver();
            isDead = true;
        }
        hpBar.SetState(currentHp, maxHp);
    }


    /// <summary>
    /// Reduces the specified amount of damage by the character's current armor value, and sets the damage value to zero if it becomes negative.
    /// </summary>
    /// <param name="damage">The amount of damage to be applied to the character's health points, passed by reference to modify its value.</param>
    private void ApplyArmor(ref int damage)
    {
        damage -= armor;
        if(damage < 0)
        {
            damage = 0;
        }
    }


    /// <summary>
    /// Increases the character's current health points by the specified amount of healing, up to a maximum of maxHp.
    /// If the character's current health points are zero or below, the method has no effect.
    /// Updates the character's health bar UI to reflect the new health value.
    /// </summary>
    /// <param name="amount">The amount of healing to be applied to the character's health points.</param>
    public void Heal(int amount)
    {
        if(currentHp <= 0) { return; }

        currentHp += amount;
        if(currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        hpBar.SetState(currentHp, maxHp);
    }
}
