using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    private void Start()
    {
        UnpauseGame();
    }

    /// <summary>
    /// Pauses the game by setting the time scale to 0, effectively stopping all time-based game mechanics.
    /// </summary>
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }


    /// <summary>
    /// Unpauses the game by setting the time scale to 1, effectively resuming all time-based game mechanics.
    /// </summary>
    public void UnpauseGame()
    {
        Time.timeScale = 1f;
    }
}
