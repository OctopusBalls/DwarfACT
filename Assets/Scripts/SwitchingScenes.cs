using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchingScenes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        /*
        if (DwarfScript.GetNumberOfTookFlag() == 1 && (SceneManager.GetActiveScene().name == "SimpleAugmentedReality"))//DwarfScript.FLAG_MAX)
        {
            SceneManager.LoadScene("Result");
        }
        else if (Input.GetMouseButtonDown(0))
        {
            //現在のシーン名を取得
            switch (SceneManager.GetActiveScene().name)
            {
                //シーン推移
                case "StartMenu":
                    SceneManager.LoadScene("SimpleAugmentedReality");
                    break;

                case "Result":
                    SceneManager.LoadScene("StartMenu");
                    break;

            }

        }
        */

        switch (SceneManager.GetActiveScene().name)
        {
            case "StartMenu":
                if(Input.GetMouseButtonDown(0)) SceneManager.LoadScene("SimpleAugmentedReality");
                break;

            case "Result":
                if (Input.GetMouseButtonDown(0)) SceneManager.LoadScene("StartMenu");
                break;

            case "SimpleAugmentedReality":
                if (ScoreManager.GetScore() == DwarfScript.FLAG_ANNOUNCE) SceneManager.LoadScene("Result");
                break;
        }
	}
}
