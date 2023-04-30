using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    public ExperienceBar experienceBar;
    public UpgradePanelManager upm;
    private int level = 1;
    private int experience = 0;
    public WeaponManager weaponManager;

    public List<UpgradeData> upgrades;
    List<UpgradeData> selectedUpgrades;
    [SerializeField] List<UpgradeData> acquiredUpgrades;

    int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }
    }

    private void Start()
    {
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        experienceBar.SetLevelText(level);
    }

    public void AddUpgradableToListOfAllAvailableUpgrades(List<UpgradeData> upgradesToAdd)
    {
        this.upgrades.AddRange(upgradesToAdd);
    }


    /// <summary>
    /// Adds a specified amount of experience points to the player character's current experience,
    /// calls the CheckLevelUp() method to check if the player has gained enough experience to level up,
    /// and updates the experience bar display with the new experience values.
    /// </summary>
    /// <param name="amount">The amount of experience points to add.</param>
    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }

    /// <summary>
    /// Checks if the player character has gained enough experience points to level up.
    /// If the current experience is greater than or equal to the required amount,
    /// calls the LevelUp() method to perform the necessary actions.
    /// </summary>
    public void CheckLevelUp()
    {
        if(experience >= TO_LEVEL_UP)
        {
            LevelUp();
        }
    }

    /// <summary>
    /// Method that handles the leveling up of the player character.
    /// Opens a UI panel to display the player's new level and any rewards earned,
    /// subtracts the required experience points from the player's current experience,
    /// increments the player's level, and updates the experience bar display.
    /// </summary>
    private void LevelUp()
    {
        if(selectedUpgrades == null) { selectedUpgrades = new List<UpgradeData>(); }
        selectedUpgrades.Clear();
        selectedUpgrades.AddRange(GetUpgrades(4));
        upm.OpenPanel(selectedUpgrades);
        experience -= TO_LEVEL_UP;
        level += 1;
        experienceBar.SetLevelText(level);
    }

    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradesList = new List<UpgradeData>();
        if(count > upgrades.Count)
        {
            count = upgrades.Count;
        }
        for(int i = 0; i < count; i++)
        {
            upgradesList.Add(upgrades[Random.Range(0, upgrades.Count)]);
        }
        return upgradesList;

    }


    public void Upgrade(int selectedUpgradeId)
    {
        UpgradeData upgradeData = selectedUpgrades[selectedUpgradeId];
        if (acquiredUpgrades == null) { acquiredUpgrades = new List<UpgradeData>(); }

       switch(upgradeData.upgradeType)
        {
            case UpgradeType.WeaponUpgrade:
                break;
            case UpgradeType.ItemUpgrade:
                break;
            case UpgradeType.WeaponUnlock:
                weaponManager.AddWeapon(upgradeData.weaponData);
                break;
            case UpgradeType.ItemUnlock:
                break;
        }

        acquiredUpgrades.Add(upgradeData);
        upgrades.Remove(upgradeData);

    }    
}
