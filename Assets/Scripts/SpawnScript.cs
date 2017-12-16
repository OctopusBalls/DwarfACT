using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    public GameObject spawnObject;
    public float interval = 10.0f;

	// Use this for initialization
	void Start () {
        StartCoroutine("Spawn");
	}

    IEnumerator Spawn()
    {
        while (true)
        {
            spawnObject = Instantiate(spawnObject, transform.position, Quaternion.identity) as GameObject;
            //spawnObject.AddComponent<MoveScript>();
            
            yield return new WaitForSeconds(interval);
        }

    }                                            
}
