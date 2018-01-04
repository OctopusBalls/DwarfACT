using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tango;

public class FlagScript : MonoBehaviour {
    public TangoPointCloud pointCloud;
    public Vector3 pos;
    public Plane plane;
    public bool touchCheck = false;
    public GameObject Flag;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);
            TouchPhase p = t.phase;
            touchCheck = true;
            if(p == TouchPhase.Ended)
            {
                StartCoroutine(FindPlane(t.position));
            }
        }
        else
        {
            touchCheck = false;
        }
        
	}

    private IEnumerator FindPlane(Vector2 touchPosition)
    {
        Camera cam = Camera.main;
        Instantiate(Flag);
        
        if(!pointCloud.FindPlane(cam,touchPosition,out pos,out plane))
        {
            yield break;
        }
        Flag.transform.position = pos;
         Flag.transform.forward = new Vector3(
            cam.transform.position.x - Flag.transform.position.x,
            0,
            cam.transform.position.z - Flag.transform.position.z).normalized;
    }
}
