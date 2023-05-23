using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class that handles the player's win condition and displays a win message.
/// </summary>
public class PlayerWinManager : MonoBehaviour
{
    public GameObject winMessagePanel;
    public PauseManager pauseManager;
    public DataContainer dataContainer;

    /// <summary>
    /// Activates the win message panel and pauses the game.
    /// </summary>
    public void Win()
    {
        winMessagePanel.SetActive(true);
        pauseManager.PauseGame();
        dataContainer.StageComplete(0);
    }
}

