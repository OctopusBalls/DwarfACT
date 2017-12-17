﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchingScenes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            //現在のシーン名を取得
            switch (SceneManager.GetActiveScene().name)
            {
                //シーン推移
                case "StartMenu":
                    SceneManager.LoadScene("MarkerTracking");
                    break;

                case "Result":
                    SceneManager.LoadScene("StartMenu");
                    break;

            }

        }
	}
}
