using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An enumeration that defines the types of stage events
public enum StageEventType
{
    SpawnEnemy, // Spawn an enemy or a group of enemies
    SpawnEnemyBoss, // Spawn an enemy boss or a group of enemy bosses with special abilities
    SpawnObject, // Spawn an object or a group of objects
    WinStage // Win the stage and proceed to the next one
}

// A class that represents an event that happens during a stage
[Serializable]
public class StageEvent
{
    public StageEventType eventType; // The type of the event
    public float time; // The time (in seconds) when the event occurs
    public string message; // The message to display when the event occurs
    public EnemyData enemyToSpawn; // The enemy data to use for spawning an enemy (only used for SpawnEnemy events)
    public GameObject objectToSpawn; // The game object to use for spawning an object (only used for SpawnObject events)
    public int count; // The number of enemies or objects to spawn (only used for SpawnEnemy and SpawnObject events)
}

// A scriptable object that contains a list of stage events
[CreateAssetMenu]
public class StageData : ScriptableObject
{
    public List<StageEvent> stageEvents; // The list of stage events
}
