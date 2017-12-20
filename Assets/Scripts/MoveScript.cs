using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {
    public CharacterController m_characterController;
    [SerializeField]
    public GameObject target;
    public Vector3 moveDirection;

	float speed = 0.5f;
	float jumpOffHeight = 2.0f;
	float stoppingDistance = 0.5f;
	float forwardDistance = 0.1f;

    // Use this for initialization
    void Start () {

        m_characterController = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        
        RaycastHit forwardHitInfo;
		bool forwardHitCheck = false;

        if(m_characterController != null)
        {
            
            moveDirection = target.transform.position - m_characterController.transform.position;
            moveDirection.y = 0;

			if (moveDirection.magnitude > stoppingDistance && forwardHitCheck == false)
            {
                moveDirection = transform.TransformDirection(moveDirection.normalized * speed);
                m_characterController.transform.LookAt(target.transform);

                Quaternion tmpRotation = new Quaternion(0, m_characterController.transform.rotation.y, 0, 1);
                m_characterController.transform.rotation = tmpRotation;
                //移動アニメーション再生
            }
            else
            {
                //停止アニメーション再生
            }
            
            if(Physics.Raycast(m_characterController.transform.position,Vector3.forward,out forwardHitInfo, forwardDistance))
            {
				forwardHitCheck = true;
                transform.rotation = Quaternion.AngleAxis(180, new Vector3(0,1,0));
            }
            else
            {
				forwardHitCheck = false;
            }

            if (!m_characterController.isGrounded)
            {
                RaycastHit hitInfo;
                if(Physics.Raycast(m_characterController.transform.position,Vector3.down*2,out hitInfo, jumpOffHeight))
                {
                    moveDirection.y -= 9.8f;
                }
                else
                {

                }
            }
            m_characterController.Move(moveDirection * Time.deltaTime);
        }
	}
}
