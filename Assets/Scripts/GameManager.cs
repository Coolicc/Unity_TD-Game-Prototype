using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool gameEnded;
    public GameObject gameOverUI;
    public int currentLevelIndex;
    public GameObject levelWonUI;

	// Use this for initialization
	void Start () {
        gameEnded = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (gameEnded) {
            return;
        }

        if (PlayerStats.Lives <= 0) {
            GameOver();
        }
	}

    void GameOver() {
        gameEnded = true;
        gameOverUI.SetActive(true);
    }

    public void LevelWon() {
        gameEnded = true;
        int nextLevelIndex = currentLevelIndex + 1;
        if (nextLevelIndex > PlayerPrefs.GetInt("levelReached", 1)) {
            PlayerPrefs.SetInt("levelReached", nextLevelIndex);
        }
        levelWonUI.SetActive(true);
    }
}
