using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    private int gameScore;

	// Use this for initialization
	void Start () {
        gameScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = gameScore.ToString();
	}
}
