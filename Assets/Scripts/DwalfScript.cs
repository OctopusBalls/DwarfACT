﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwalfScript: MonoBehaviour {
    public CharacterController m_characterController;
    [SerializeField]
    public GameObject target;
    public Transform lookTarget;
    public Vector3 moveDirection;
    private Animation Anim;
    private GameObject rayCube;
    private GameObject FlagCube;


	float speed = 0.5f;
	float jumpOffHeight = 2.0f;
	float stoppingDistance = 0.5f;
	float forwardDistance = 0.1f;
    bool flagHit = false;

    // Use this for initialization
    void Start () {

        m_characterController = GetComponent<CharacterController>();
        rayCube = transform.FindChild("Cube").gameObject;
        FlagCube = GameObject.Find("FlagCube");
        Anim = this.gameObject.GetComponent<Animation>();

    }
	
	// Update is called once per frame
	void Update () {
        
        if(m_characterController != null)
        {
            if (!rayCube.GetComponent<Hit_DetectionScript>().meshHit)
            {
                //moveDirection = m_characterController.transform.position;
                rayCube.GetComponent<Hit_DetectionScript>().meshHit = true;
				moveDirection.y = -9.8f;
            }
            else
            {
                moveDirection = target.transform.position - m_characterController.transform.position;
            }

            if (!flagHit)
            {
                //moveDirection.y -= 9.8f;
                
				//m_characterController.Move(moveDirection * Time.deltaTime);
            }
			m_characterController.Move(moveDirection * Time.deltaTime);
			transform.LookAt(new Vector3(lookTarget.transform.position.x, transform.position.y, lookTarget.transform.position.z));
        }

        if (!flagHit)
        {
            //移動アニメーション再生
            Anim.Stop("Idle");
            Anim.Play("Move");

        }
        else
        {
            //停止アニメーション再生
            Anim.Stop("Move");
            Anim.Play("Idle");
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Flag")
        {
            flagHit = true;
        }
        else
        {
            flagHit = false;
        }
    }

}
