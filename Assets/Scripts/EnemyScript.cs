using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
	public CharacterController m_characterController;
	[SerializeField]
	public GameObject target;
    public GameObject spawnObject;
	public Vector3 moveDirection;
    
	private GameObject HP_UI;
    
	float speed = 0.3f;
	float jumpOffHeight = 2.0f;
	float stoppingDistance = 0.5f;
	float forwardDistance = 0.1f;

	// Use this for initialization
	void Start () {

		m_characterController = GetComponent<CharacterController>();
        target = GameObject.Find("Dwarf");
        spawnObject = GameObject.Find("SpawnPoint");
		HP_UI = transform.FindChild ("HP_UI").gameObject;
        
    }

	// Update is called once per frame
	void Update () {
		
		RaycastHit forwardHitInfo;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 vec = touch.position;
            vec.z = 10f;

            Ray ray = Camera.current.ScreenPointToRay(touch.position);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
					HP_UI.GetComponent<OperationCanvas> ().enemyHP -= 10;

					if (HP_UI.GetComponent<OperationCanvas> ().enemyHP == 0) {
						Destroy (gameObject);
					}
                }
            }

        }

        if (m_characterController != null)
		{

			moveDirection = target.transform.position - m_characterController.transform.position;
			moveDirection.y = 0;

			if (moveDirection.magnitude > stoppingDistance)
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
				transform.rotation = Quaternion.AngleAxis(180, new Vector3(1,0,0));
			}
			else
			{

			}
				
			m_characterController.Move(moveDirection * Time.deltaTime);
		}
	}
}
