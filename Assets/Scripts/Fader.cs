using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour {

    public Image fadeImage;

    IEnumerator FadeIn() {
        float t = 1f;

        while (t > 0f) {
            t -= Time.deltaTime;
            fadeImage.color = new Color(0f, 0f, 0f, t);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene) {
        float t = 0f;

        while (t < 1f) {
            t += Time.deltaTime;
            fadeImage.color = new Color(0f, 0f, 0f, t);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }

    public void FadeTo(string scene) {
        StartCoroutine(FadeOut(scene));
    }

	// Use this for initialization
	void Start () {
        StartCoroutine(FadeIn());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
