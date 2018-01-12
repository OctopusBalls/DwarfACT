using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CautionCubeScript : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	GameObject dwalf;
	GameObject cautionImage;
	GameObject cautionText;

	public bool meshHit = true;
	public float maxDistance = 0.5f;

	// Use this for initialization
	void Start () {
		cautionImage = GameObject.Find ("CautionImage");
		cautionText = GameObject.Find ("CautionText");
		ray = new Ray(transform.position, transform.up * -0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		ray.origin = transform.position;
		ray.direction = transform.up * -0.3f;
		Debug.DrawRay(ray.origin, transform.up * -maxDistance , Color.red, 1.0f, false);
		if(!Physics.Raycast(ray,out hit,maxDistance))
		{
			//Debug.Log("メッシュが先にない");
			//GameObject.Find("Canvas").transform.Find("Panel").transform.Find("Caution").gameObject.SetActive(true);
			//cautionImage.SetActive(true);
			//cautionText.SetActive (true);
			meshHit = false;
		}
		else
		{
			//Debug.Log("メッシュが先にある");
			//GameObject.Find("Canvas").transform.Find("Panel").transform.Find("Caution").gameObject.SetActive(false);
			cautionImage.SetActive(false);
			cautionText.SetActive (false);
			meshHit = true;
		}
	}
}
