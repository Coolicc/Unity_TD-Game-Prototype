using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public float generatorRate = 0.2f;
    public float generatorTimer = 5f;
    public int generatorAmount = 15;
    public GameObject generatorEffect;
    public Vector3 effectOffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (generatorTimer <= 0f) {
            Generate();
            generatorTimer = 1 / generatorRate;
        }

        generatorTimer -= Time.deltaTime;
	}

    void Generate() {
        PlayerStats.Money += generatorAmount;
        GameObject effect = (GameObject)Instantiate(generatorEffect, transform.position + effectOffset, Quaternion.identity);
        Destroy(effect, 2f);
    }
}
