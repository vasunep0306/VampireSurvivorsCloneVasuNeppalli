using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnife : WeaponBase
{
    public GameObject knifePrefab;
    public PlayerMove playerMove;

    private void Awake()
    {
        if (playerMove == null) { playerMove = GetComponentInParent<PlayerMove>(); }
    }


    public override void Attack()
    {
        GameObject throwKnife = Instantiate(knifePrefab);
        throwKnife.transform.position = transform.position;
        throwKnife.GetComponent<ThrowingKnifeProjectile>().SetDirection(playerMove.lastHorizontalVector, 0f);
    }
}
