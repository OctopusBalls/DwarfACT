using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    private static int gameScore;

	// Use this for initialization
	void Start () {
        gameScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //DwarfScriptから取得
        scoreText.text = DwarfScript.GetNumberOfTookFlag().ToString();
	}

    public void AddScore(int score)
    {
        gameScore += score;
    }

    public static int getScore() { return gameScore; }
}
