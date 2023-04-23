using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{

    public Animator animate;

    public float horizontal;

    private void Update()
    {
        animate.SetFloat("horizontal", horizontal);
    }
}
