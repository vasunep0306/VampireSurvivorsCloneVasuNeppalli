using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string sceneName = "GameplaySceneStage1";
   public void StartGameplay()
    {
        SceneManager.LoadScene("Essential", LoadSceneMode.Single);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
}
