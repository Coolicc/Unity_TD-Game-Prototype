using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string level1 = "Level1";
    public Fader fader;

    public void Play() {
        fader.FadeTo(level1);
    }

    public void Quit() {
        Debug.Log("Quit");
        Application.Quit();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
