using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class ButtonScript : MonoBehaviour{

    GameObject dynamicMesh;
    Renderer rend;
    Material StartMeshMatarials;

    private void Start()
    {
        dynamicMesh = GameObject.Find("DynamicMesh");
        rend = dynamicMesh.GetComponent<MeshRenderer>();
        StartMeshMatarials = Resources.Load<Material>("MeshMaterials");
    }

    public void OnClick(){
        Debug.Log("Button Click");
        //rend.material = StartMeshMatarials;
        rend.sharedMaterial = StartMeshMatarials;
        gameObject.SetActive(false);
        gameObject.SetActive(true);
    } 
}
