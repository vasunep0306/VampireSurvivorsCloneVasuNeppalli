using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : WeaponBase
{
    
    public GameObject leftWhip;
    public GameObject rightWhip;
    public PlayerMove playerMove;

    public Vector2 attackSize = new Vector2(4f, 2f);
   
    

    private void Awake()
    {
        if (playerMove == null) { playerMove = GetComponentInParent<PlayerMove>(); }
    }

   

    

    private void ApplyDamage(Collider2D[] colliders)
    {
        for(int i=0; i< colliders.Length; i++)
        {
            IDamagable e = colliders[i].GetComponent<IDamagable>();
            if (e != null)
            {
                PostMessage(weaponsStats.damage, colliders[i].transform.position);
                e.TakeDamage(weaponsStats.damage);
            }
        }
    }

    public override void Attack()
    {
        StartCoroutine(AttackProcess());
    }



    /// <summary>
    /// A coroutine that performs the attack process by activating the whip and applying damage to the colliders in the attack area.
    /// </summary>
    /// <returns>A yield instruction that waits for 0.3 seconds between each attack.</returns>
    IEnumerator AttackProcess()
    {
        for(int i = 0; i < weaponsStats.numberOfAttacks; i++)
        {
            if (playerMove.lastHorizontalVector > 0)
            {
                rightWhip.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhip.transform.position, attackSize, 0f);
                ApplyDamage(colliders);
            }
            else
            {
                leftWhip.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhip.transform.position, attackSize, 0f);
                ApplyDamage(colliders);
            }
            yield return new WaitForSeconds(0.3f);
        }
    }    
}
