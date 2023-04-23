using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public PlayerMove playerMove;
    public GameObject allWeapons;

    public void CharacterGameOver()
    {
        Debug.Log("Game Over");
        playerMove.enabled = false;
        gameOverPanel.SetActive(true);
        allWeapons.SetActive(false);
    }
}
