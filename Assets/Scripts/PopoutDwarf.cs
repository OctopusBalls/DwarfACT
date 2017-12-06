using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopoutDwarf : MonoBehaviour {

    public GameObject originDwarfModel;
    private GameObject clonedDwarfModel;

    int POPOUT_MAX = 5;

	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    void Update()
    {
        GameObject hitGameObject = GetClickObject();
        if (hitGameObject != null)
        {
            switch (hitGameObject.name)
            {
                case "Door":
                    for (int i = 0; i < POPOUT_MAX; i++)
                    {
                        clonedDwarfModel = Object.Instantiate(originDwarfModel) as GameObject;

                        Transform myTransform = this.transform;

                        float popoutX = myTransform.position.x + Random.Range(-0.15f, 0.15f);
                        float popoutY = originDwarfModel.transform.position.y;
                        float popoutZ = myTransform.position.z + Random.Range(-0.15f, 0.15f);

                        clonedDwarfModel.transform.position = new Vector3(popoutX, popoutY, popoutZ);
                    }
                    break;
            }
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
