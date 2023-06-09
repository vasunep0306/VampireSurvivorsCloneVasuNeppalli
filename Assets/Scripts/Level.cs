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
    public PassiveItem passiveItems;

    public List<UpgradeData> upgrades;
    List<UpgradeData> selectedUpgrades;
    [SerializeField] List<UpgradeData> acquiredUpgrades;
    [SerializeField] List<UpgradeData> upgradesAvailableOnStart;

    int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }
    }

    private void Awake()
    {
        if(passiveItems == null) { passiveItems = GetComponent<PassiveItem>(); }
    }

    private void Start()
    {
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        experienceBar.SetLevelText(level);
        AddUpgradableToListOfAllAvailableUpgrades(upgradesAvailableOnStart);
    }

    /// <summary>
    ///  Adds a list of upgrade data objects to the existing list of upgrades for this object, if the list is not null. 
    /// </summary>
    /// <param name="upgradesToAdd">The list of upgrade data objects to be added, or null to skip.</param>
    public void AddUpgradableToListOfAllAvailableUpgrades(List<UpgradeData> upgradesToAdd)
    {
        if(upgradesToAdd == null) { return; }
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

    public void ShuffleUpgrades()
    {
        for(int i = upgrades.Count - 1; i > 0; i--)
        {
            int x = Random.Range(0, i + 1);
            UpgradeData shuffleElement = upgrades[i];
            upgrades[i] = upgrades[x];
            upgrades[x] = shuffleElement;
        }
    }

    public List<UpgradeData> GetUpgrades(int count)
    {
        ShuffleUpgrades();
        List<UpgradeData> upgradesList = new List<UpgradeData>();
        if(count > upgrades.Count)
        {
            count = upgrades.Count;
        }
        for(int i = 0; i < count; i++)
        {
            upgradesList.Add(upgrades[i]);
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
                weaponManager.UpgradeWeapon(upgradeData);
                break;
            case UpgradeType.ItemUpgrade:
                passiveItems.upgradeItem(upgradeData);
                break;
            case UpgradeType.WeaponGet:
                weaponManager.AddWeapon(upgradeData.weaponData);
                break;
            case UpgradeType.ItemGet:
                passiveItems.Equip(upgradeData.item);
                AddUpgradableToListOfAllAvailableUpgrades(upgradeData.item.upgrades);
                break;
        }

        acquiredUpgrades.Add(upgradeData);
        upgrades.Remove(upgradeData);

    }    
}
