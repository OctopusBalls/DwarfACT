using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetSleepTimer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "SimpleAugmentedReality")
        {
            //カメラ起動中は無操作が多いので、スリープ時間を無効に
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
        else
        {
            //それ以外のシーンではシステムのデフォルト
            Screen.sleepTimeout = SleepTimeout.SystemSetting;
        }
	}
}
