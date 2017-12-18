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
            }
            

            if (moveDirection.magnitude > stoppingDistance)
            {
                //移動アニメーション再生
				stayAnim.Play("Move");

            }
            else
            {
                //停止アニメーション再生
                stayAnim.Play("Idle");
            }            

			moveDirection.y -= 9.8f;
            transform.LookAt(new Vector3(lookTarget.transform.position.x, transform.position.y, lookTarget.transform.position.z));
            m_characterController.Move(moveDirection * Time.deltaTime);

        }
	}
}
