using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    public ExperienceBar experienceBar;
    public UpgradePanelManager upm;
    private int level = 1;
    private int experience = 0;

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
        upm.OpenPanel();
        experience -= TO_LEVEL_UP;
        level += 1;
        experienceBar.SetLevelText(level);
    }
}
