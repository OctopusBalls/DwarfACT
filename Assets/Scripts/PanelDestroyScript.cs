using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDestroyScript : MonoBehaviour {

    public float DestroyWaitTimer;
	// Use this for initialization
	void Start () {
		if(DestroyWaitTimer == 0.0f)
        {
            DestroyWaitTimer = 10.0f;
        }
	}
	
	// Update is called once per frame
	void Update () {
        DestroyWaitTimer -= Time.deltaTime;

        if(DestroyWaitTimer < 0.0f)
        {
            GameObject.Destroy(this.gameObject);
        }
	}
}
