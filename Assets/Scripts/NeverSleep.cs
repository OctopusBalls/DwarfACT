using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeverSleep : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //カメラ起動中は無操作が多いので、スリープ時間を無効に
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
