using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnife : MonoBehaviour
{
    public float timeToAttack;
    float timer;

    public GameObject knifePrefab;
    public PlayerMove playerMove;

    private void Awake()
    {
        if (playerMove == null) { playerMove = GetComponentInParent<PlayerMove>(); }
    }

    private void Update()
    {
        if (timer < timeToAttack)
        {
            timer += Time.deltaTime;
            return;
        }
        timer = 0;
        SpawnKnife();
    }

    private void SpawnKnife()
    {
        GameObject throwKnife = Instantiate(knifePrefab);
        throwKnife.transform.position = transform.position;
        throwKnife.GetComponent<ThrowingKnifeProjectile>().SetDirection(playerMove.lastHorizontalVector, 0f);
      
        
    }
}
