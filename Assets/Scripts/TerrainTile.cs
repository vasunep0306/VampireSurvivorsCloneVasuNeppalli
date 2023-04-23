using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTile : MonoBehaviour
{
    public Vector2Int tilePosition;
    public WorldScrolling ws;
    public List<SpawnObject> spawnObjects;

    void Start()
    {
        ws.Add(gameObject, tilePosition);

        transform.position = new Vector3(-100f, -100f, 0f);
    }

    public void Spawn()
    {
       for(int i =0; i < spawnObjects.Count; i++)
        {
            spawnObjects[i].Spawn();
        }
    }
}
