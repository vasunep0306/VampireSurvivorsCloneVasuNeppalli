using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesManager : MonoBehaviour
{
    // Declares variables for the enemy game object, its animation, the spawn area size, and the spawn timer duration.
    public StageProgress stageProgress;
    public GameObject enemy;
    public Vector2 spawnArea;
    public float spawnTimer;
    public Slider bossHealthBar;

    // Declares variables for the player game object and its character component.
    private GameObject player;
    private Character playerCharacter;

    // Declare a list of boss enemies and two variables to store their total and current health
    private List<Enemy> bossEnemiesList;
    private int totalBossHealth;
    private int currentBossHealth;



    private void Start()
    {
        player = GameManager.instance.playerTransform.gameObject;
        playerCharacter = GameManager.instance.playerCharacter;
        bossHealthBar = FindObjectOfType<BossHPBar>(true).GetComponent<Slider>();
    }

    private void Update()
    {
        UpdateBossHealth();
    }

    private void UpdateBossHealth()
    {
        if (bossEnemiesList == null) { return; }
        if (bossEnemiesList.Count <= 0) { return; }

        currentBossHealth = 0;
        for(int i = 0; i < bossEnemiesList.Count; i++)
        {
            if(bossEnemiesList[i] == null) { continue; }
            currentBossHealth += bossEnemiesList[i].stats.hp;
        }

        bossHealthBar.value = currentBossHealth;

        if (currentBossHealth <= 0)
        {
            bossHealthBar.gameObject.SetActive(false);
            bossEnemiesList.Clear();
        }
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
    public void SpawnEnemy(EnemyData enemyToSpawn, bool isBoss)
    {
        Vector3 position = UtilityTools.GenerateRandomPositionSquarePattern(spawnArea);

        // Creates a new enemy instance at the given position, sets its target to the player, and makes it a child of this object.
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
        Enemy newEnemyComponent = newEnemy.GetComponent<Enemy>();
        newEnemyComponent.SetTarget(player.transform, playerCharacter);
        newEnemyComponent.SetStats(enemyToSpawn.stats);
        newEnemyComponent.UpdateStatsForProgress(stageProgress.Progress);

        if(isBoss)
        {
            SpawnBossEnemy(newEnemyComponent);
        }

        newEnemy.transform.parent = transform;

        // Creates a new sprite object for the enemy animation and makes it a child of the new enemy.
        GameObject spriteObject = Instantiate(enemyToSpawn.animatedPrefab);
        spriteObject.transform.parent = newEnemy.transform;
        spriteObject.transform.localPosition = Vector3.zero;
    }

    private void SpawnBossEnemy(Enemy newBoss)
    {
        if(bossEnemiesList == null) { bossEnemiesList = new List<Enemy>(); }
        bossEnemiesList.Add(newBoss);

        totalBossHealth += newBoss.stats.hp;

        bossHealthBar.gameObject.SetActive(true);
        bossHealthBar.maxValue = totalBossHealth;

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
