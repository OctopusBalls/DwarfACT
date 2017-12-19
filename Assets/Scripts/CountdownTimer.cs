using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour {
    private float limitTime;
    public Text sourceText;

    // Use this for initialization
    void Start()
    {
        limitTime = 180.0f;
        //limitTime = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(limitTime <= 0.0f)
        {
            SceneManager.LoadScene("Result");
        }
        else{
            /*
            int minute = (int)limitTime / 60;
            int second = (int)limitTime % 60;

            sourceText.text = minute.ToString() + ":" + second.ToString();
            */

            int nowTime = (int)limitTime;
            sourceText.text = nowTime.ToString("D3");
            limitTime -= Time.deltaTime;
        }
    }
}
