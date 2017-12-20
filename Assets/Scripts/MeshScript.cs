using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tango;

public class MeshScript : MonoBehaviour {
    public TangoPointCloud pointCloud;
    public Vector3[] vertices;
    public Vector3 startPos;
    public Vector3 endPos;
    public Vector3 pos;
    public Plane plane;
    public Material material;
    public PhysicMaterial physicMaterial;

	// Use this for initialization
	void Start () {
        /* Vector3[] vertices =
        {
            new Vector3(-1f,-1f,0),
            new Vector3(-1f,1f,0),
            new Vector3(1f,1f,0),
            new Vector3(1f,-1f,0)
        };

        int[] triangles = { 0, 1, 2, 0, 2, 3 };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();

        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        if (!meshFilter) meshFilter = gameObject.AddComponent<MeshFilter>();

        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        if (!meshRenderer) meshRenderer = gameObject.AddComponent<MeshRenderer>();

        MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
        if (!meshCollider) meshCollider = gameObject.AddComponent<MeshCollider>();


        meshFilter.mesh = mesh;
        meshRenderer.sharedMaterial = material;
        meshCollider.sharedMesh = mesh;
        meshCollider.sharedMaterial = physicMaterial; */
	}
	
	// Update is called once per frame
	void Update () {
        /*if(Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);
            TouchPhase p = t.phase;
            if(p == TouchPhase.Ended)
            {
                StartCoroutine(FindPlane(t.position));
            }
        }*/
        Vector3[] vertices =
        {
            new Vector3(-1f,-1f,0),
            new Vector3(-1f,1f,0),
            new Vector3(1f,1f,0),
            new Vector3(1f,-1f,0)
        };

        int[] triangles = { 0, 1, 2, 0, 2, 3 };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();

        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        if (!meshFilter) meshFilter = gameObject.AddComponent<MeshFilter>();

        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        if (!meshRenderer) meshRenderer = gameObject.AddComponent<MeshRenderer>();

        MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
        if (!meshCollider) meshCollider = gameObject.AddComponent<MeshCollider>();


        meshFilter.mesh = mesh;
        meshRenderer.sharedMaterial = material;
        meshCollider.sharedMesh = mesh;
        meshCollider.sharedMaterial = physicMaterial;
    }

    private IEnumerator FindPlane(Vector2 touchPosition)
    {
        Camera cam = Camera.main;

        if (!pointCloud.FindPlane(cam, touchPosition, out pos, out plane))
        {
            yield break;
        }
        startPos = pos;
        
    }
}
