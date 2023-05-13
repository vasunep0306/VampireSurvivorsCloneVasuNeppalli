using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    // Declares variables for the enemy game object, its animation, the spawn area size, and the spawn timer duration.
    public StageProgress stageProgress;
    public GameObject enemy;
    public Vector2 spawnArea;
    public float spawnTimer;

    // Declares variables for the player game object and its character component.
    private GameObject player;
    private Character playerCharacter;

    //float timer;

    private void Start()
    {
        player = GameManager.instance.playerTransform.gameObject;
        playerCharacter = GameManager.instance.playerCharacter;
    }

    //private void Update()
    //{
    //    timer -= Time.deltaTime;
    //    if(timer < 0f)
    //    {
    //        SpawnEnemy();
    //        timer = spawnTimer;
    //    }
    //}

    /// <summary>
    /// Spawns an enemy game object at a randomly generated position and sets the player as the enemy's target.
    /// </summary>
    public void SpawnEnemy(EnemyData enemyToSpawn)
    {
        Vector3 position = GenerateRandomPosition();

        // Creates a new enemy instance at the given position, sets its target to the player, and makes it a child of this object.
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
        Enemy newEnemyComponent = newEnemy.GetComponent<Enemy>();
        newEnemyComponent.SetTarget(player.transform, playerCharacter);
        newEnemyComponent.SetStats(enemyToSpawn.stats);
        newEnemyComponent.UpdateStatsForProgress(stageProgress.Progress);

        newEnemy.transform.parent = transform;

        // Creates a new sprite object for the enemy animation and makes it a child of the new enemy.
        GameObject spriteObject = Instantiate(enemyToSpawn.animatedPrefab);
        spriteObject.transform.parent = newEnemy.transform;
        spriteObject.transform.localPosition = Vector3.zero;
    }


    /// <summary>
    /// Generates a random position within a defined spawn area.
    /// </summary>
    /// <returns>A Vector3 representing the generated random position.</returns>
    private Vector3 GenerateRandomPosition()
    {
        Vector3 position= new Vector3();
        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else
        {
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
        }
        position.z = 0f;
        return position;
    }
}
