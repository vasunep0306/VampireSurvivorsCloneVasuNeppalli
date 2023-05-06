using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class that controls the animation of a game object.
/// </summary>
public class Animate : MonoBehaviour
{

    public Animator animate;

    public float horizontal;

    private void Update()
    {
        animate.SetFloat("horizontal", horizontal);
    }
}
