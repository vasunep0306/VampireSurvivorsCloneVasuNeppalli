using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    public StageData stageData;
    public StageTime stageTime;
    public EnemiesManager enemiesManager;

    private int eventIndexer = 0;
    private PlayerWinManager win;

    private void Awake()
    {
        if(stageTime == null) { stageTime = GetComponent<StageTime>(); }
    }

    private void Start()
    {
        win = FindObjectOfType<PlayerWinManager>();
    }


    private void Update()
    {
        if(eventIndexer >= stageData.stageEvents.Count) { return; }
        if(stageTime.time > stageData.stageEvents[eventIndexer].time)
        {
            switch (stageData.stageEvents[eventIndexer].eventType)
            {
                case StageEventType.SpawnEnemy:
                    SpawnEnemies(false);
                    break;
                case StageEventType.SpawnObject:
                    SpawnObjects();
                    break;
                case StageEventType.SpawnEnemyBoss:
                    SpawnEnemyBoss();
                    break;
                case StageEventType.WinStage:
                    WinStage();
                    break;
            }

            Debug.Log(stageData.stageEvents[eventIndexer].message);
            
            eventIndexer += 1;
        }
    }

    private void SpawnEnemyBoss()
    {
        SpawnEnemies(true);
    }

    private void WinStage()
    {
        win.Win();
    }

    private void SpawnObjects()
    {
        for (int i = 0; i < stageData.stageEvents[eventIndexer].count; i++)
        {
            Vector3 positionToSpawn = GameManager.instance.playerTransform.position;
            positionToSpawn += UtilityTools.GenerateRandomPositionSquarePattern(new Vector2(5f, 5f));
            SpawnManager.instance.SpawnObject(
               positionToSpawn,
                stageData.stageEvents[eventIndexer].objectToSpawn
               );
        }
    }

    /// <summary>
    /// Spawns a number of enemies based on the current stage event
    /// </summary>
    private void SpawnEnemies(bool isBoss)
    {
        StageEvent currentEvent = stageData.stageEvents[eventIndexer];
        enemiesManager.AddGroupToSpawn(currentEvent.enemyToSpawn, currentEvent.count, isBoss);
    }



}
