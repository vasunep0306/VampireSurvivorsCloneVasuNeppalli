using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMessage : MonoBehaviour
{
    public float timeToLive = 2f;
    float ttl;


    private void OnEnable()
    {
        ttl = timeToLive;
    }

    private void Update()
    {
        ttl -= Time.deltaTime;
        if(ttl < 0f)
        {
            gameObject.SetActive(false);
        }
    }
}
