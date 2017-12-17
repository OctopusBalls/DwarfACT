using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwalfScript: MonoBehaviour {
    public CharacterController m_characterController;
    [SerializeField]
    public GameObject target;
    public Transform lookTarget;
    public Vector3 moveDirection;
    private Animation stayAnim;
    private GameObject rayCube;


	float speed = 0.5f;
	float jumpOffHeight = 2.0f;
	float stoppingDistance = 0.5f;
	float forwardDistance = 0.1f;

    // Use this for initialization
    void Start () {

        m_characterController = GetComponent<CharacterController>();
        rayCube = transform.FindChild("Cube").gameObject;
        stayAnim = this.gameObject.GetComponent<Animation>();

    }
	
	// Update is called once per frame
	void Update () {
        
        RaycastHit forwardHitInfo;

        if(m_characterController != null)
        {
            if (!rayCube.GetComponent<Hit_DetectionScript>().meshHit)
            {
                //moveDirection = m_characterController.transform.position;
                rayCube.GetComponent<Hit_DetectionScript>().meshHit = true;
            }
            else
            {
                moveDirection = target.transform.position - m_characterController.transform.position;
                //moveDirection.y = 0;
				moveDirection.y -= 9.8f;
<<<<<<< HEAD
=======
               
>>>>>>> 352de85eac2c59a06d39616e3ae72961063bd3d4
            }
            

            if (moveDirection.magnitude > stoppingDistance)
            {
<<<<<<< HEAD
                //移動アニメーション再生
				stayAnim.Play("Move");

=======

                //transform.LookAt(new Vector3(lookTarget.transform.position.x,transform.position.y,lookTarget.transform.position.z));
                /*moveDirection = transform.TransformDirection(moveDirection.normalized * speed);
                m_characterController.transform.LookAt(target.transform);

                Quaternion tmpRotation = new Quaternion(0, m_characterController.transform.rotation.y, 0, 1);
                m_characterController.transform.rotation = tmpRotation;*/
                //移動アニメーション再生
                
>>>>>>> 352de85eac2c59a06d39616e3ae72961063bd3d4
            }
            else
            {
                //停止アニメーション再生
<<<<<<< HEAD
                stayAnim.Play("Idle");
=======
                stayAnim.Play();
>>>>>>> 352de85eac2c59a06d39616e3ae72961063bd3d4
            }
            
            if(Physics.Raycast(m_characterController.transform.position,Vector3.forward,out forwardHitInfo, forwardDistance))
            {
                //transform.rotation = Quaternion.AngleAxis(180, new Vector3(0,1,0));
            }
            else
            {
<<<<<<< HEAD
				
            }

			moveDirection.y -= 9.8f;
            transform.LookAt(new Vector3(lookTarget.transform.position.x, transform.position.y, lookTarget.transform.position.z));
            m_characterController.Move(moveDirection * Time.deltaTime);

=======
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
            transform.LookAt(new Vector3(lookTarget.transform.position.x, transform.position.y, lookTarget.transform.position.z));
            m_characterController.Move(moveDirection * Time.deltaTime);
>>>>>>> 352de85eac2c59a06d39616e3ae72961063bd3d4
        }
	}
}
