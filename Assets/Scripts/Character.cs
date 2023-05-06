using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 1000;
    public int currentHp = 1000;
    public StatusBar hpBar;

    public int armor = 0;

    public Level level;
    public Coins coins;

    public float hpRegenerationRate = 1f;
    public float hpRegenerationTimer;


    public GameOver gameOver;

    private bool isDead = false;

    private void Start()
    {
        hpBar.SetState(currentHp, maxHp);
        coins.Add(0);
    }

    private void Update()
    {
        hpRegenerationTimer += Time.deltaTime * hpRegenerationRate;

        if(hpRegenerationTimer > 1f)
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
