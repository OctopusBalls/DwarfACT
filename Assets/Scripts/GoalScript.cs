using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour {

    public bool hitCheck = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider hit)
    {
        if (hit is CharacterController)
        {
            //hitCheck = true;
			SceneManager.LoadScene("Result");
            Destroy(gameObject);
        }
        else
        {
            //hitCheck = false;
        }
        

    }
}
