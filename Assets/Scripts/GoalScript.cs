using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.SceneManagement;
=======
>>>>>>> 352de85eac2c59a06d39616e3ae72961063bd3d4

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
<<<<<<< HEAD
            //hitCheck = true;
			SceneManager.LoadScene("Result");
=======
            hitCheck = true;
>>>>>>> 352de85eac2c59a06d39616e3ae72961063bd3d4
            Destroy(gameObject);
        }
        else
        {
<<<<<<< HEAD
            //hitCheck = false;
=======
            hitCheck = false;
>>>>>>> 352de85eac2c59a06d39616e3ae72961063bd3d4
        }
        

    }
}
