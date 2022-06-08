using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LevelWon : MonoBehaviour {

    public Fader fader;
    public string mainMenuSceneName = "MainMenu";
    public GameManager gameManager;
    public AudioSource musicAudioSource;
    public AudioSource buttonAudioSource;

    public void NextLevel() {
        buttonAudioSource.Play();
        int nextLevelIndex = gameManager.currentLevelIndex + 1;
        fader.FadeTo("Level" + nextLevelIndex);
    }

    public void ReturnToMenu() {
        buttonAudioSource.Play();
        fader.FadeTo(mainMenuSceneName);
    }

    void OnEnable() {
        musicAudioSource.Stop();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
