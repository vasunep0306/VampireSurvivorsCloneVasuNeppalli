using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    public StageData stageData;
    public StageTime stageTime;
    public EnemiesManager enemiesManager;

    private int eventIndexer = 0;

    private void Awake()
    {
        if(stageTime == null) { stageTime = GetComponent<StageTime>(); }
    }


    private void Update()
    {
        if(eventIndexer >= stageData.stageEvents.Count) { return; }
        if(stageTime.time > stageData.stageEvents[eventIndexer].time)
        {
            switch (stageData.stageEvents[eventIndexer].eventType)
            {
                case StageEventType.SpawnEnemy:
                    SpawnEnemies();
                    break;
                case StageEventType.SpawnObject:
                    break;
                case StageEventType.WinStage:
                    break;
            }

            Debug.Log(stageData.stageEvents[eventIndexer].message);
            
            eventIndexer += 1;
        }
    }

    /// <summary>
    /// Spawns a number of enemies based on the current stage event
    /// </summary>
    private void SpawnEnemies()
    {
        for (int i = 0; i < stageData.stageEvents[eventIndexer].count; i++)
        {
            enemiesManager.SpawnEnemy(stageData.stageEvents[eventIndexer].enemyToSpawn);
        }
    }
}
