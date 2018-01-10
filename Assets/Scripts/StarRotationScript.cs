using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRotationScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.eulerAngles += new Vector3(0.0f, 10.0f, 0.0f);
	}
}
