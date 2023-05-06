using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class that represents a terrain tile in the world.
/// </summary>
public class TerrainTile : MonoBehaviour
{
    public Vector2Int tilePosition; // The position of the tile in the world grid.
    public WorldScrolling ws; // The reference to the world scrolling component.
    public List<SpawnObject> spawnObjects; // The list of spawn objects on the tile.

    /// <summary>
    /// Initializes the tile and adds it to the world scrolling component.
    /// </summary>
    void Start()
    {
        ws.Add(gameObject, tilePosition);

        // Moves the tile to an invisible position until it is needed.
        transform.position = new Vector3(-100f, -100f, 0f);
    }

    /// <summary>
    /// Spawns the objects on the tile with a random chance.
    /// </summary>
    public void Spawn()
    {
        for (int i = 0; i < spawnObjects.Count; i++)
        {
            spawnObjects[i].Spawn();
        }
    }
}
