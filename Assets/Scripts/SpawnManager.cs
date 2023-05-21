using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A class that manages the spawning of objects in the scene
public class SpawnManager : MonoBehaviour
{

    public static SpawnManager instance; // A static reference to the SpawnManager instance

    private void Awake()
    {
        instance = this; // Assigns the instance to this object
    }

    /// <summary>
    /// Spawns an object at a given world position
    /// </summary>
    /// <param name="worldPosition">The position in world space where the object should be spawned</param>
    /// <param name="toSpawn">The game object to spawn</param>
    public void SpawnObject(Vector3 worldPosition, GameObject toSpawn)
    {
        Transform t = Instantiate(toSpawn, transform).transform; // Creates a new instance of the object and gets its transform component
        t.position = worldPosition; // Sets the position of the transform to the world position
    }
}
