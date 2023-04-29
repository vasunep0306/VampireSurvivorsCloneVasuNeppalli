using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
{
    public GameObject panel;
    public PauseManager pmanager;


    /// <summary>
    /// Closes the panel associated with this script, resumes gameplay by calling the UnpauseGame() method,
    /// and deactivates the panel game object.
    /// </summary>
    public void ClosePanel()
    {
        pmanager.UnpauseGame();
        panel.SetActive(false);
    }


    /// <summary>
    /// Opens the panel associated with this script, pauses gameplay by calling the PauseGame() method,
    /// and activates the panel game object.
    /// </summary>
    public void OpenPanel()
    {
        pmanager.PauseGame();
        panel.SetActive(true);
    }
}
