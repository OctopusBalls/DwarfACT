using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelButtonScript : MonoBehaviour {

    GameObject cancelObject;
    GameObject flagObject;
    GameObject OKButton;
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
        OKButton = GameObject.Find("OKButton");
        CancelButton = GameObject.Find("CancelButton");
        cancelObject = GameObject.Find("Flag");
        GameObject.Destroy(cancelObject);
        OKButton.SetActive(false);
        CancelButton.SetActive(false);
        flagObject.GetComponent<FlagScript>().setFlag = false;

    }
}
