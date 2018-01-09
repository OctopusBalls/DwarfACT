using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIScript : MonoBehaviour {

    GameObject checkTarget;
    GameObject dwalfObject;
    GameObject goalObject;

    public GUIStyleState styleState;
    GUIStyle style;

    FlagScript flagScript;
    DwarfScript dwarfScript;
    GoalScript goalScript;
    
	// Use this for initialization
	void Start () {

        checkTarget = GameObject.Find("Pin");
        dwalfObject = GameObject.Find("dowa-hu_kari3");
        goalObject = GameObject.Find("yama kari2");

        styleState = new GUIStyleState();
        style = new GUIStyle();
        style.fontSize = 60;

        flagScript = checkTarget.GetComponent<FlagScript>();
		dwarfScript = dwalfObject.GetComponent<DwarfScript>();
        goalScript = goalObject.GetComponent<GoalScript>();
	}
	
	// Update is called once per frame
	void Update () {
	}
    
    private void OnGUI()
    {
        styleState.textColor = Color.red;
        style.normal = styleState;
        /*if(goalScript.hitCheck != false)
        {
            GUI.Label(new Rect(0, 100, 100, 30), "Hit!!",style);
        }*/
    }
}
