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


    /// <summary>
    /// Sets the target destination and character for a given object.
    /// </summary>
    /// <param name="destination">The Transform of the target destination.</param>
    /// <param name="character">The Character object associated with the target destination.</param>
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

    /// <summary>
    /// Inflicts damage to the target character object.
    /// </summary>
    private void Attack()
    {
        targetCharacter.TakeDamage(damage);
    }

    /// <summary>
    /// Applies damage to the object's health points and checks if the object is destroyed.
    /// </summary>
    /// <param name="damage">The amount of damage to apply to the object's health points.</param>
    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp < 1)
        {
            targetGameObject.GetComponent<Level>().AddExperience(experience_reward);
            GetComponent<DropAndDestroy>().CheckDrop();
            Destroy(gameObject);

        }
    }
}
