using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMenu : MonoBehaviour
{

    /// <summary>
    /// Loads the main menu scene.
    /// </summary>
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
