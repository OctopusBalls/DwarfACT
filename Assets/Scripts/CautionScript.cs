using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CautionScript : MonoBehaviour {

	private GameObject cautionImage;
	private GameObject cautionText;
	private GameObject cautionCube;

	// Use this for initialization
	void Start () {
		cautionImage = GameObject.Find ("CautionImage");
		cautionText = GameObject.Find ("CautionText");
		cautionCube = GameObject.Find ("CautionCube");
		GameObject.Find("Canvas").transform.Find("Panel").transform.Find("Caution").gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
