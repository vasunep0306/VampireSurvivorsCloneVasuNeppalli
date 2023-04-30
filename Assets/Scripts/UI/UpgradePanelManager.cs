using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
{
    public GameObject panel;
    public PauseManager pmanager;

    public List<UpgradeButton> upgradeButtons;


    private void Start()
    {
        HideButtons();
    }

    /// <summary>
    /// Closes the panel associated with this script, resumes gameplay by calling the UnpauseGame() method,
    /// and deactivates the panel game object.
    /// </summary>
    public void ClosePanel()
    {
        HideButtons();

        pmanager.UnpauseGame();
        panel.SetActive(false);
    }

    private void HideButtons()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(false);
        }
    }


    /// <summary>
    /// Opens the panel associated with this script, pauses gameplay by calling the PauseGame() method,
    /// and activates the panel game object.
    /// </summary>
    public void OpenPanel(List<UpgradeData> upgradeDatas)
    {
        Clean();
        pmanager.PauseGame();
        panel.SetActive(true);

        for(int i = 0; i < upgradeDatas.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(true);
            upgradeButtons[i].Set(upgradeDatas[i]);
        }
    }


    public void Clean()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].Clean();
        }
    }

    public void Upgrade(int pressButtonId)
    {
        GameManager.instance.playerTransform.GetComponent<Level>().Upgrade(pressButtonId);
        ClosePanel();
    }
}
