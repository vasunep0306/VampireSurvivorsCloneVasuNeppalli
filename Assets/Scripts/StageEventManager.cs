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
            Debug.Log(stageData.stageEvents[eventIndexer].message);
            SpawnEnemies();
            eventIndexer += 1;
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < stageData.stageEvents[eventIndexer].count; i++)
        {
            enemiesManager.SpawnEnemy();
        }
    }
}
