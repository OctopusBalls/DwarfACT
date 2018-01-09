using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DrawResult : MonoBehaviour {
    public Text timeText;
    public Text scoreText;
    public Text TotalText;

    private int totalScore;

	// Use this for initialization
	void Start () {

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
