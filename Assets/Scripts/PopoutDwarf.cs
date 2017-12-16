<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 51febdc4c5f1abf7f7c537dac80203723fbbbdb1
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopoutDwarf : MonoBehaviour {

    public GameObject originDwarfModel;
    private GameObject clonedDwarfModel;

    private Animator animator;

    private bool calledFlag = false;

    int POPOUT_MAX = 5;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();

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
                    if (!calledFlag)
                    {
                        animator.Play("Open", 0, 0.0f);

                        for (int i = 0; i < POPOUT_MAX; i++)
                        {
                            clonedDwarfModel = Object.Instantiate(originDwarfModel) as GameObject;
                            clonedDwarfModel.name = originDwarfModel.name;

                            Transform doorTransform = this.transform;

                            float popoutX = doorTransform.position.x + Random.Range(-0.15f, 0.15f);
                            float popoutY = doorTransform.position.y + 0.07f;
                            float popoutZ = doorTransform.position.z + Random.Range(-0.15f, 0.15f);

                            clonedDwarfModel.transform.position = new Vector3(popoutX, popoutY, popoutZ);
                        }

                        calledFlag = true;
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
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopoutDwarf : MonoBehaviour {

    public GameObject originDwarfModel;
    private GameObject clonedDwarfModel;

    private Animator animator;

    private bool calledFlag = false;

    int POPOUT_MAX = 5;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();

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
                    if (!calledFlag)
                    {
                        animator.Play("Open", 0, 0.0f);

                        for (int i = 0; i < POPOUT_MAX; i++)
                        {
                            clonedDwarfModel = Object.Instantiate(originDwarfModel) as GameObject;
                            clonedDwarfModel.name = originDwarfModel.name;

                            Transform doorTransform = this.transform;

                            float popoutX = doorTransform.position.x + Random.Range(-0.15f, 0.15f);
                            float popoutY = doorTransform.position.y + 0.07f;
                            float popoutZ = doorTransform.position.z + Random.Range(-0.15f, 0.15f);

                            clonedDwarfModel.transform.position = new Vector3(popoutX, popoutY, popoutZ);
                        }

                        calledFlag = true;
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
>>>>>>> develop
<<<<<<< HEAD
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopoutDwarf : MonoBehaviour {

    public GameObject originDwarfModel;
    private GameObject clonedDwarfModel;

    private Animator animator;

    private bool calledFlag = false;

    int POPOUT_MAX = 5;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();

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
                    if (!calledFlag)
                    {
                        animator.Play("Open", 0, 0.0f);

                        for (int i = 0; i < POPOUT_MAX; i++)
                        {
                            clonedDwarfModel = Object.Instantiate(originDwarfModel) as GameObject;
                            clonedDwarfModel.name = originDwarfModel.name;

                            Transform doorTransform = this.transform;

                            float popoutX = doorTransform.position.x + Random.Range(-0.15f, 0.15f);
                            float popoutY = doorTransform.position.y + 0.07f;
                            float popoutZ = doorTransform.position.z + Random.Range(-0.15f, 0.15f);

                            clonedDwarfModel.transform.position = new Vector3(popoutX, popoutY, popoutZ);
                        }

                        calledFlag = true;
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
>>>>>>> develop
=======
>>>>>>> 51febdc4c5f1abf7f7c537dac80203723fbbbdb1
