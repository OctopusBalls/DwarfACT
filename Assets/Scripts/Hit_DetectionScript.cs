using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_DetectionScript : MonoBehaviour {

    Ray ray;
    RaycastHit hit;
    GameObject dwalf;
    public bool meshHit = true;
	public float maxDistance = 0.5f;
    // Use this for initialization
    void Start () {
        ray = new Ray(transform.position, transform.up * -0.1f);
        dwalf = transform.root.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        ray.origin = transform.position;
        ray.direction = transform.up * -0.3f;
		Debug.DrawRay(ray.origin, transform.up * -maxDistance , Color.red, 1.0f, false);
		if(!Physics.Raycast(ray,out hit,maxDistance))
        {
            //Debug.Log("メッシュが先にない");
            dwalf.gameObject.GetComponent<DwalfScript>().moveDirection = Vector3.zero;
            meshHit = false;
        }
        else
        {
            //Debug.Log("メッシュが先にある");
            //dwalf.gameObject.GetComponent<DwalfScript>().moveDirection.y += 0.1f;
            meshHit = true;
        }
	}
}