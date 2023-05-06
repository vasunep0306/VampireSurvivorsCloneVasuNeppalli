using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string sceneName = "GameplaySceneStage1";

    /// <summary>
    /// This method loads the essential scene in single mode and the gameplay scene in additive mode.
    /// </summary>
    public void StartGameplay()
    {
        SceneManager.LoadScene("Essential", LoadSceneMode.Single);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
}
