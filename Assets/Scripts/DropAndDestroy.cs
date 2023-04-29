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


    /// <summary>
    /// Determines whether an item should be dropped based on the configured drop chance, and instantiates a drop item prefab if the drop chance is successful.
    /// </summary>
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
