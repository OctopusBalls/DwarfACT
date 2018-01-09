using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tango;

public class FlagScript : MonoBehaviour {
    public TangoPointCloud pointCloud;
    public Vector3 pos;
    public Plane plane;
    public GameObject Flag;
    private GameObject cloneFlag;
    GameObject CancelButton;
    public bool setFlag = false;

    // Use this for initialization
    void Start () {
        CancelButton = GameObject.Find("CancelButton");
        CancelButton.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);
            TouchPhase p = t.phase;
            if(p == TouchPhase.Began && setFlag == false)
            {
                setFlag = true;
                StartCoroutine(FindPlane(t.position));
            }
        }
        
	}

    private IEnumerator FindPlane(Vector2 touchPosition)
    {
        Camera cam = Camera.main;
        cloneFlag = (GameObject)Instantiate(Flag);
        cloneFlag.name = Flag.name;
        
        if(!pointCloud.FindPlane(cam,touchPosition,out pos,out plane))
        {
            yield break;
        }
        cloneFlag.transform.position = pos;
         cloneFlag.transform.forward = new Vector3(
            cam.transform.position.x - cloneFlag.transform.position.x,
            0,
            cam.transform.position.z - cloneFlag.transform.position.z).normalized;
        CancelButton.SetActive(true);
    }

    public void OnClick()
    {
        setFlag = false;
        GameObject.Destroy(cloneFlag);
    }
    
}
