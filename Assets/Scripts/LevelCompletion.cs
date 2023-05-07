using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    public float timeToCompleteLevel;
    public StageTime stageTime;


    private GameWinPanel levelCompletePanel;
    private PauseManager pauseManager;


    private void Awake()
    {
        if(stageTime == null) { stageTime = GetComponent<StageTime>(); }
        pauseManager = FindObjectOfType<PauseManager>();
        levelCompletePanel = FindObjectOfType<GameWinPanel>(true);
    }

    private void Update()
    {
        if(stageTime.time > timeToCompleteLevel)
        {
            pauseManager.PauseGame();
            levelCompletePanel.gameObject.SetActive(true);
        }
    }
}
