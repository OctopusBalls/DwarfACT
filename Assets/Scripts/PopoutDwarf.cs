using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopoutDwarf : MonoBehaviour {

    public GameObject originDwarfModel;
    private GameObject clonedDwarfModel;

	// Use this for initialization
	void Start () {
        clonedDwarfModel = Object.Instantiate(originDwarfModel) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        Transform myTransform = this.transform;

        float popoutX = myTransform.position.x + Random.Range(-1.0f, 1.0f);
        float popoutZ = myTransform.position.z + Random.Range(-1.0f, 1.0f);

        clonedDwarfModel.transform.position = new Vector3(popoutX, myTransform.position.y, popoutZ);
    }
}
