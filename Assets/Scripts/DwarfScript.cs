using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DwarfScript: MonoBehaviour {
    public CharacterController m_characterController;
    [SerializeField]
    public GameObject target;
    public Transform lookTarget;
    public Vector3 moveDirection;
    private Animation stayAnim;
    private GameObject rayCube;
    private GameObject flagCube;
	private GameObject scoreManager;
    private Vector3 angels;


	public float speed = 0.1f;
    float rotationSpeed = 6.0f;
	int dwarfFallCount = 0;
    bool flagHit = false;
    static bool rightButton = false;
    static bool leftButton = false;
    //rightButtonとleftButtonは押されているとtrue 押されていないとfalse

    // Use this for initialization
    void Start () {

        m_characterController = GetComponent<CharacterController>();
        rayCube = transform.FindChild("Cube").gameObject;
        flagCube = GameObject.Find("FlagCube");
		scoreManager = GameObject.Find("ScoreManager");
        stayAnim = this.gameObject.GetComponent<Animation>();
        angels = new Vector3(0.0f, rotationSpeed, 0.0f);

    }

    public void OnRightUp()
    {
        rightButton = false;
    }

    public void OnLeftUp()
    {
        leftButton = false;
    }

    public void OnRightDown()
    {
        rightButton = true;
    }


    public void OnLeftDown()
    {
        leftButton = true;
    }


    // Update is called once per frame
    void Update () {

        if(rightButton)
        {
			this.transform.eulerAngles += new Vector3(0.0f, rotationSpeed + 2.0f, 0.0f);
        }

        if(leftButton)
        {
			this.transform.eulerAngles += new Vector3(0.0f, (rotationSpeed + 2.0f) * -1.0f, 0.0f);
        }

        InvokeRepeating("ResetAngles", Random.Range(0.0f, 2.0f), Random.Range(0.0f, 2.0f));

        if(m_characterController != null)
        {
			//メッシュがなかった場合
            if (!rayCube.GetComponent<Hit_DetectionScript>().meshHit)
            {
                this.transform.position += new Vector3(0.0f, -0.1f, 0.0f);
				dwarfFallCount++;
                //rayCube.GetComponent<Hit_DetectionScript>().meshHit = true;
            }
        }

        this.transform.eulerAngles += angels;        
        m_characterController.Move(this.transform.forward * speed * Time.deltaTime);
        
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

	//CharacterControllerがColliderに触れた場合に実行
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
            scoreManager.GetComponent<ScoreManager>().AddScore(10);
            //hit.gameObject.GetComponent<ScoreManager>().AddScore(10);
        }
    }

	//IsTriggerになっている山に触れた瞬間に実行
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Yama")
        {
            scoreManager.GetComponent<ScoreManager>().AddScore(10);
        }
    }

    private void ResetAngles()
    {
        angels *= -1;
        CancelInvoke("ResetAngles");
    }

}
