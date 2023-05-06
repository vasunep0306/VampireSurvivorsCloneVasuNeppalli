using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// A class that represents a button for selecting an upgrade.
/// </summary>
public class UpgradeButton : MonoBehaviour
{
    public Image icon; // The image component of the button.

    /// <summary>
    /// Sets the icon of the button based on the upgrade data.
    /// </summary>
    /// <param name="upgradeData">The upgrade data to be displayed.</param>
    public void Set(UpgradeData upgradeData)
    {
        icon.sprite = upgradeData.icon;
    }

    /// <summary>
    /// Clears the icon of the button.
    /// </summary>
    public void Clean()
    {
        icon.sprite = null;
    }
}

