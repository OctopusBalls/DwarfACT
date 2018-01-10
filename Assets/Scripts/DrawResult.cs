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
        int nowScore = CountdownTimer.getNowTime();
        RollNumber(nowScore, timeText);

        int gameScore = ScoreManager.getScore();
        RollNumber(gameScore, scoreText);

        int totallScore = nowScore + gameScore;
        RollNumber(totallScore, totalText);
;	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void RollNumber(int max, Text* OutText)
    {
        for(int i = 0; i < max; i++)
        {
            OutText.text = i.ToString();
        }
    }
}
