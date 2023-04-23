using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    private Transform targetDestination;
    private Character targetCharacter;
    public float speed = 2f;



    public int hp = 10;
    public int damage = 1;
    public int experience_reward = 400;

    private GameObject targetGameObject;
    private Rigidbody2D rb;

    private void Awake()
    {
        //targetGameObject = targetDestination.gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(Transform destination, Character character)
    {
        targetDestination = destination;
        targetCharacter = character;
        targetGameObject = targetDestination.gameObject;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        direction *= speed;
        rb.velocity = direction * Time.deltaTime; // add * Time.deltatime for frame rate independence
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameObject)
        {
            Attack();
        }

    }

    private void Attack()
    {
        targetCharacter.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp < 1)
        {
            //targetGameObject.GetComponent<Level>().AddExperience(experience_reward);
            GetComponent<DropAndDestroy>().CheckDrop();
            Destroy(gameObject);

        }
    }
}
