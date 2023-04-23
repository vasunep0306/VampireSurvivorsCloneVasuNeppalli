using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    public Animate animate;

    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;

    [HideInInspector]
    public Vector3 movementVector;
    // Start is called before the first frame update
    void Awake()
    {
        movementVector = new Vector3();
    }

    private void Start()
    {
        lastHorizontalVector = -1f;
        lastVerticalVector = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        PopulateLastMovement();

        animate.horizontal = movementVector.x;

        movementVector *= speed;

        rb.velocity = movementVector * Time.deltaTime; // In this example, we multiply our movementVector with Time.deltaTime to make our game frame rate independent.
    }

    private void PopulateLastMovement()
    {
        if (movementVector.x != 0)
        {
            lastHorizontalVector = movementVector.x;
        }
        if(movementVector.y != 0)
        {
            lastVerticalVector = movementVector.y;
        }
    }
}
