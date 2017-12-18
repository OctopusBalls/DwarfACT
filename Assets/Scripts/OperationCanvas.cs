using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tango;
using TangoExtensions;

public class OperationCanvas : MonoBehaviour {

    public Slider slider;
	public GameObject camera;
    public int maxEnemyHP;
    public int enemyHP;

	// Use this for initialization
	void Start () {
        slider.maxValue = maxEnemyHP;
        slider.value = enemyHP;
        camera = GameObject.FindWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = enemyHP;
		transform.LookAt(new Vector3(camera.transform.position.x, transform.position.y, camera.transform.position.z));
	}
   
}
