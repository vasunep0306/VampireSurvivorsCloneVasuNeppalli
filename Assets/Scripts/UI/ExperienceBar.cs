using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    public Slider slider;
    public TMPro.TextMeshProUGUI levelText;


    /// <summary>
    /// Updates the experience slider with the current and target values.
    /// </summary>
    /// <param name="current">The current experience value.</param>
    /// <param name="target">The target experience value.</param>
    public void UpdateExperienceSlider(int current, int target)
    {
        slider.maxValue = target;
        slider.value = current;
    }


    /// <summary>
    /// Sets the level text with the given level number.
    /// </summary>
    /// <param name="level">The level number to be displayed in the level text.</param>
    public void SetLevelText(int level)
    {
        levelText.text = $"LEVEL: {level}";
    }
}
