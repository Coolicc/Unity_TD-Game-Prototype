using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameOver : MonoBehaviour {

    public Fader fader;
    public string mainMenuSceneName = "MainMenu";
    public AudioSource musicAudioSource;

    public void RestartLevel() {
        fader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu() {
        fader.FadeTo(mainMenuSceneName);
    } 

    // Use this for initialization
    void Start () {
		
	}

    void OnEnable() {
        musicAudioSource.Stop();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
