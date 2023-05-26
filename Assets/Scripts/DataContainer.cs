using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerPersistentUpgrades
{
    HP,
    DAMAGE
}

[Serializable]
public class PlayerUpgrades
{
    public PlayerPersistentUpgrades playerPersistentUpgrades;
    public int level = 0;
    public int costToUpgrade = 100;
}

[CreateAssetMenu]
public class DataContainer : ScriptableObject
{
    public int coins;

    public List<bool> stageCompletion;

    public List<PlayerUpgrades> upgrades;

    public void StageComplete(int i)
    {
        stageCompletion[i] = true;
    }

    public int GetUpgradeLevel(PlayerPersistentUpgrades persistentUpgrade)
    {
        return upgrades[(int)persistentUpgrade].level;
    }
}
