using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
    public Fader fader;
    public string mainMenuSceneName = "MainMenu";
    public AudioSource pauseAudioSource;
    public AudioSource resumeAudioSource;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Toggle();
        }
	}

    public void Toggle() {
        pauseMenu.SetActive(!pauseMenu.activeSelf);

        if (pauseMenu.activeSelf) {
            Time.timeScale = 0f;
            pauseAudioSource.Play();
        } else {
            Time.timeScale = 1f;
            resumeAudioSource.Play();
        }
    }

    public void RestartLevel() {
        Toggle();
        fader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu() {
        Toggle();
        fader.FadeTo(mainMenuSceneName);
    }
}
