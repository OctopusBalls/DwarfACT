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
    void Update()
    {
        GameObject reslutGameObject = GetClickObject();
        if (reslutGameObject != null && reslutGameObject.name == "Door")
        {
            Transform myTransform = this.transform;

            float popoutX = myTransform.position.x + Random.Range(-0.05f, 0.05f);
            float popoutZ = myTransform.position.z + Random.Range(-0.05f, 0.05f);

            clonedDwarfModel.transform.position = new Vector3(popoutX, myTransform.position.y, popoutZ);
        }
    }

    public GameObject GetClickObject()
    {
        GameObject result = null;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if(Physics.Raycast(ray, out hit))
            {
                result = hit.collider.gameObject;
            }
        }

        return result;
    }
}
