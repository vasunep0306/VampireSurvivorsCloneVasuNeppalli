using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAndDestroy : MonoBehaviour
{
    public GameObject dropItemPrefab;
    [Range(0f, 1f)] public float chance = 1f;

    private bool isQuitting = false;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    public void CheckDrop()
    {
        if(isQuitting) { return; }

        if(Random.value < chance)
        {
            Transform t = Instantiate(dropItemPrefab).transform;
            t.position = transform.position;
        }
    }
}
