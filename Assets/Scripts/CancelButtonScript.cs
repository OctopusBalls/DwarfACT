using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelButtonScript : MonoBehaviour {

    GameObject cancelObject;
    GameObject flagObject;
    GameObject CancelButton;

    // Use this for initialization
    void Start () {
        flagObject = GameObject.Find("flagCreate");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        CancelButton = GameObject.Find("CancelButton");
        //cancelObject = GameObject.Find("Flag");
        //GameObject.Destroy(cancelObject);
        CancelButton.SetActive(false);
		//GameObject.Find("Canvas").transform.Find("Panel").transform.Find("Caution").gameObject.SetActive(false);
        flagObject.GetComponent<FlagScript>().setFlag = false;

    }
}
