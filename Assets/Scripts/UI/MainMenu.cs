using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject panel;
    public PauseManager pmanager;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(panel.activeInHierarchy)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }
        
    }

    /// <summary>
    /// Closes the in-game menu panel and resumes gameplay by calling the UnpauseGame() method
    /// and deactivating the menu panel game object.
    /// </summary>
    public void CloseMenu()
    {
        pmanager.UnpauseGame();
        panel.SetActive(false);
    }


    /// <summary>
    /// Opens the in-game menu panel and pauses gameplay by calling the PauseGame() method
    /// and activating the menu panel game object.
    /// </summary>
    public void OpenMenu()
    {
        pmanager.PauseGame();
        panel.SetActive(true);
    }
}
