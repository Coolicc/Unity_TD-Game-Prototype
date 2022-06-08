using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public int startMoney = 500;
    public static int Lives;
    public int startLives = 20;
    public static int wavesSurvived;

	// Use this for initialization
	void Start () {
        Money = startMoney;
        Lives = startLives;
        wavesSurvived = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
