using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A class that handles dropping and destroying items when a game object is destroyed.
/// </summary>
public class DropAndDestroy : MonoBehaviour
{
    public List<GameObject> dropItemPrefab;
    [Range(0f, 1f)] public float chance = 1f;

    private bool isQuitting = false;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }


    /// <summary>
    /// Checks if an item should be dropped and spawns it at the current position.
    /// </summary>
    /// <remarks>
    /// This function is called when the game object is destroyed.
    /// It uses a random value to determine if an item should be dropped and which item to drop from a list of prefabs.
    /// It also checks if the game is quitting or if the drop item prefab is null and returns early if so.
    /// It uses the SpawnManager instance to spawn the item at the current position.
    /// </remarks>
    public void CheckDrop()
    {
        if(isQuitting) { return; }

        if (dropItemPrefab.Count <= 0)
        {
            Debug.LogWarning("Drop and destroy dropItemPrefab is empty. Add some prefabs to the list.");
            return;
        }
        if(Random.value < chance)
        {
            GameObject toDrop = dropItemPrefab[Random.Range(0, dropItemPrefab.Count)];
            if(toDrop == null)
            {
                Debug.LogWarning("Drop and destroy toDrop is null. Check the prefab");
                return;
            }
            SpawnManager.instance.SpawnObject(transform.position, toDrop);
        }
    }
}
