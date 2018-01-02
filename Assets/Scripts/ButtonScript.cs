using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class ButtonScript : MonoBehaviour{

    public GameObject dynamicMesh;
    Renderer rend;
    Shader shader1;
    public Material ReadyMeshMaterials;
    public Material StartMeshMatarials;
    private void Start()
    {
        dynamicMesh = GameObject.Find("DynamicMesh");
        rend = dynamicMesh.GetComponent<Renderer>();
        ReadyMeshMaterials = Resources.Load<Material>("ReadyMeshMaterial");
        StartMeshMatarials = Resources.Load<Material>("MeshMaterials");
    }

    public void OnClick(){
        Debug.Log("Button Click");
        rend.material = StartMeshMatarials;
    } 
}
