using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class that spawns a game object with a given probability.
/// </summary>
public class SpawnObject : MonoBehaviour
{
    public GameObject toSpawn; // The game object to be spawned.
    [Range(0f, 1f)] public float probability; // The probability of spawning the game object.

    /// <summary>
    /// Spawns the game object at the current position with a random chance.
    /// </summary>
    public void Spawn()
    {
        if (Random.value < probability)
        {
            GameObject go = Instantiate(toSpawn, transform.position, Quaternion.identity);
        }
    }
}
