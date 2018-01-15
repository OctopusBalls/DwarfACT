using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DrawResult : MonoBehaviour {
    public Text timeText;
    public Text scoreText;
    public Text totalText;
    
	// Use this for initialization
	void Start ()
    {
        int nowScore = CountdownTimer.GetNowTime();
        timeText.text = nowScore.ToString();
        //RollNumber(nowScore, timeText);

        int gameScore = ScoreManager.GetScore();
        scoreText.text = gameScore.ToString();
        //RollNumber(gameScore, scoreText);

        int totalScore = nowScore + gameScore;
        totalText.text = totalScore.ToString();
        //RollNumber(totallScore, totalText);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void RollNumber(int max, Text OutText)
    {
        for(int i = 0; i < max; i++)
        {
            OutText.text = i.ToString();
        }
    }
}
