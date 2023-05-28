using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesSpawnGroup
{
    public EnemyData enemyData; // The data of the enemy to spawn
    public int count; // The number of enemies to spawn at once
    public bool isBoss; // Whether the enemy is a boss or not
    public float repeatTimer; // The timer for repeating the spawn (only used if repeatCount > 0)
    public float timeBetweenSpawn; // The time interval between each spawn repetition
    public int repeatCount; // The number of times to repeat the spawn

    public EnemiesSpawnGroup(EnemyData enemyData,int count, bool isBoss)
    {
        this.enemyData = enemyData;
        this.count = count;
        this.isBoss = isBoss;
    }

    public void SetRepeatSpawn(float timeBetweenSpawn, int repeatCount)
    {
        this.timeBetweenSpawn = timeBetweenSpawn;
        this.repeatCount = repeatCount;
        repeatTimer = timeBetweenSpawn;
    }
}

public class EnemiesManager : MonoBehaviour
{
    // Declares variables for the enemy game object, its animation, the spawn area size, and the spawn timer duration.
    public StageProgress stageProgress;
    public GameObject enemy;
    public Vector2 spawnArea;
    public Slider bossHealthBar;
    public int spawnPerFrame = 2;

    // Declares variables for the player game object and its character component.
    private GameObject player;
    private Character playerCharacter;

    // Declare a list of boss enemies and two variables to store their total and current health
    private List<Enemy> bossEnemiesList;
    private int totalBossHealth;
    private int currentBossHealth;

    private List<EnemiesSpawnGroup> enemiesSpawnGroups;
    private List<EnemiesSpawnGroup> repeatedSpawnGroupList;

    

    private void Start()
    {
        player = GameManager.instance.playerTransform.gameObject;
        playerCharacter = GameManager.instance.playerCharacter;
        //bossHealthBar = FindObjectOfType<BossHPBar>(true).GetComponent<Slider>();
        stageProgress = FindObjectOfType<StageProgress>();
    }

    private void Update()
    {
        ProcessSpawn();
        ProcessRepeatedSpawnGroup();
        UpdateBossHealth();
    }

    private void ProcessRepeatedSpawnGroup()
    {
        if(repeatedSpawnGroupList == null)
        {
            return;
        }
        for(int i = repeatedSpawnGroupList.Count - 1; i >= 0; i--)
        {
            repeatedSpawnGroupList[i].repeatTimer -= Time.deltaTime;
            if(repeatedSpawnGroupList[i].repeatTimer < 0)
            {
                repeatedSpawnGroupList[i].repeatTimer = repeatedSpawnGroupList[i].timeBetweenSpawn;
                AddGroupToSpawn(repeatedSpawnGroupList[i].enemyData, repeatedSpawnGroupList[i].count, repeatedSpawnGroupList[i].isBoss);
                repeatedSpawnGroupList[i].repeatCount -= 1;
                if(repeatedSpawnGroupList[i].repeatCount <=0 )
                {
                    repeatedSpawnGroupList.RemoveAt(i);
                }
            }
        }
    }

    private void ProcessSpawn()
    {
        if(enemiesSpawnGroups == null){ return; }

        for (int i = 0; i < spawnPerFrame; i++)
        {
            if(enemiesSpawnGroups.Count > 0)
            {
                if (enemiesSpawnGroups[0].count <= 0) { return; }
                SpawnEnemy(enemiesSpawnGroups[0].enemyData, enemiesSpawnGroups[0].isBoss);
                enemiesSpawnGroups[0].count -= 1;

                if(enemiesSpawnGroups[0].count <= 0)
                {
                    enemiesSpawnGroups.RemoveAt(0);
                }
            }
        }
    }

    /// <summary>
    /// Updates the boss health bar based on the total health of all boss enemies in the list
    /// </summary>
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

    

    public void AddGroupToSpawn(EnemyData enemyToSpawn, int count, bool isBoss)
    {
        EnemiesSpawnGroup newGroupToSpawn = new EnemiesSpawnGroup(enemyToSpawn, count, isBoss);
        if(enemiesSpawnGroups == null) { enemiesSpawnGroups = new List<EnemiesSpawnGroup>(); }

        enemiesSpawnGroups.Add(newGroupToSpawn);

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
        // Generate a random position within the spawn area using a square pattern
        Vector3 position = UtilityTools.GenerateRandomPositionSquarePattern(spawnArea);
        // Create a new enemy game object from the prefab and get its Enemy component
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
        Enemy newEnemyComponent = newEnemy.GetComponent<Enemy>();
        // Initialize the enemy's target, stats, and difficulty based on the player and the stage progress
        newEnemyComponent.SetTarget(player.transform, playerCharacter);
        newEnemyComponent.SetStats(enemyToSpawn.stats);
        newEnemyComponent.UpdateStatsForProgress(stageProgress.Progress);
        // Add the enemy to the boss list if it is a boss and set its parent to this object
        if (isBoss)
        {
            SpawnBossEnemy(newEnemyComponent);
        }

        newEnemy.transform.parent = transform;
        // Creates a new sprite object for the enemy animation and makes it a child of the new enemy.
        GameObject spriteObject = Instantiate(enemyToSpawn.animatedPrefab);
        spriteObject.transform.parent = newEnemy.transform;
        spriteObject.transform.localPosition = Vector3.zero;
    }

    /// <summary>
    /// Adds a new boss enemy to the list and updates the boss health bar accordingly
    /// </summary>
    /// <param name="newBoss">The new boss enemy to be added</param>
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

    public void AddRepeatedSpawn(StageEvent stageEvent, bool isBoss)
    {
        EnemiesSpawnGroup repeatSpawnGroup = new EnemiesSpawnGroup(stageEvent.enemyToSpawn, stageEvent.count, isBoss);
        repeatSpawnGroup.SetRepeatSpawn(stageEvent.repeatEverySeconds, stageEvent.repeatCount);

        if(repeatedSpawnGroupList==null) { repeatedSpawnGroupList = new List<EnemiesSpawnGroup>(); }

        repeatedSpawnGroupList.Add(repeatSpawnGroup);
    }
}
