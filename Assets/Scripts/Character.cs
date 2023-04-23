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


    public GameOver gameOver;

    private bool isDead = false;

    private void Start()
    {
        hpBar.SetState(currentHp, maxHp);
        coins.Add(0);
    }

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

    private void ApplyArmor(ref int damage)
    {
        damage -= armor;
        if(damage < 0)
        {
            damage = 0;
        }
    }

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
