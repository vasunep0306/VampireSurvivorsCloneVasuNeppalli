using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUpgradeUIElement : MonoBehaviour
{
    public PlayerPersistentUpgrades upgrade;

    public TextMeshProUGUI upgradeName;
    public TextMeshProUGUI level;
    public TextMeshProUGUI price;

    public DataContainer dataContainer;

    private void Start()
    {
        UpdateElement();
    }

    public void Upgrade()
    {
        PlayerUpgrades playerUpgrade = dataContainer.upgrades[(int)upgrade];

        if(dataContainer.coins >= playerUpgrade.costToUpgrade)
        {
            dataContainer.coins -= playerUpgrade.costToUpgrade;
            playerUpgrade.level += 1;
            UpdateElement();
        }
    }

    void UpdateElement()
    {
        PlayerUpgrades playerUpgrade = dataContainer.upgrades[(int)upgrade];

        upgradeName.text = upgrade.ToString();
        level.text = playerUpgrade.level.ToString();
        price.text = playerUpgrade.costToUpgrade.ToString();
    }
}
