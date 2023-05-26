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
    public float lastHorizontalDecoupledVector;
    [HideInInspector]
    public float lastVerticalDecoupledVector;

    [HideInInspector]
    public float lastHorizontalCoupledVector;
    [HideInInspector]
    public float lastVerticalCoupledVector;

    [HideInInspector]
    public Vector3 movementVector;
    // Start is called before the first frame update
    void Awake()
    {
        movementVector = new Vector3();
    }

    private void Start()
    {
        lastHorizontalDecoupledVector = -1f;
        lastVerticalDecoupledVector = 1f;

        lastHorizontalCoupledVector = -1f;
        lastVerticalCoupledVector = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        PopulateLastCoupledMovement();
        PopulateLastDecoupledMovement();

        animate.horizontal = movementVector.x;

        movementVector *= speed;

        rb.velocity = movementVector * Time.deltaTime; // In this example, we multiply our movementVector with Time.deltaTime to make our game frame rate independent.
    }

    private void PopulateLastCoupledMovement()
    {
        if (movementVector.x != 0 || movementVector.y != 0)
        {
            lastHorizontalCoupledVector = movementVector.x;
            lastVerticalCoupledVector = movementVector.y;
        }
    }


    /// <summary>
    /// Updates the last horizontal and vertical movement values based on the current movement vector.
    /// </summary>
    private void PopulateLastDecoupledMovement()
    {
        if (movementVector.x != 0)
        {
            lastHorizontalDecoupledVector = movementVector.x;
        }
        if(movementVector.y != 0)
        {
            lastVerticalDecoupledVector = movementVector.y;
        }
    }
}
