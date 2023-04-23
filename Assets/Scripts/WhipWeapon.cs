using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{
    public float timeToAttack = 4f;
    public GameObject leftWhip;
    public GameObject rightWhip;
    public PlayerMove playerMove;
    public int whipDamage;

    public Vector2 whipAttackSize = new Vector2(4f, 2f);
   
    private float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
        }
    }

    private void Attack()
    {
        timer = timeToAttack;

        if(playerMove.lastHorizontalVector > 0)
        {
            rightWhip.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhip.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
        else
        {
            leftWhip.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhip.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for(int i=0; i< colliders.Length; i++)
        {
            IDamagable e = colliders[i].GetComponent<IDamagable>();
            if (e != null)
            {
                e.TakeDamage(whipDamage);
            }
        }
    }
}
