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
    private GameObject FlagCube;
    private Vector3 angels;


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
        stayAnim = this.gameObject.GetComponent<Animation>();
        angels = new Vector3(0.0f, 3.0f, 0.0f);

    }
	
	// Update is called once per frame
	void Update () {

        InvokeRepeating("ResetTimer", Random.Range(0.0f, 5.0f), Random.Range(1.0f, 5.0f));
        /*if(m_characterController != null)
        {
            if (!rayCube.GetComponent<Hit_DetectionScript>().meshHit)
            {
                //moveDirection = m_characterController.transform.position;
                rayCube.GetComponent<Hit_DetectionScript>().meshHit = true;
            }
            else
            {
                moveDirection = target.transform.position - m_characterController.transform.position;
				moveDirection.y -= 9.8f;
            }

            if (!flagHit)
            {
                moveDirection.y -= 9.8f;
                transform.LookAt(new Vector3(lookTarget.transform.position.x, transform.position.y, lookTarget.transform.position.z));
                m_characterController.Move(moveDirection * Time.deltaTime);
            }
        }*/

        this.transform.eulerAngles += angels;

        if (!flagHit)
        {
            //移動アニメーション再生
            stayAnim.Stop("Idle");
            stayAnim.Play("Move");

        }
        else
        {
            //停止アニメーション再生
            stayAnim.Stop("Move");
            stayAnim.Play("Idle");
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
        
        //Yamaに当たった場合、ScoreManagerのAddScoreを実行
        if(hit.gameObject.tag == "Yama")
        {
            hit.gameObject.GetComponent<ScoreManager>().AddScore(10);
        }
    }

    private void ResetTimer()
    {
        angels *= -1;
        CancelInvoke("ResetTimer");
    }
}
