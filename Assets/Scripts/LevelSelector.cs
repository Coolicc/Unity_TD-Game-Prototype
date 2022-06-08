using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    public Fader fader;
    public Button[] buttons;

    public void Select(string level) {
        fader.FadeTo(level);
    }

    // Use this for initialization
    void Start () {

        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = levelReached; i < buttons.Length; i++) {
            buttons[i].interactable = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
