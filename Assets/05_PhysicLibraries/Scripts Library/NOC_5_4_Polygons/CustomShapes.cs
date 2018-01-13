using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomShapes : MonoBehaviour
{

    public GameObject Polygons;
    public static List<GameObject> Polies = new List<GameObject>();

    public Material mat;

    float width = 1;
    float height = 1;

    private void Start()
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[4];

        vertices[0] = new Vector3((width - 0.15f), (height + 0.25f));
        vertices[1] = new Vector3((width + 0.15f), height);
        vertices[2] = new Vector3((width + 0.20f), (height - 0.15f));
        vertices[3] = new Vector3((width - 0.10f), (height - 0.10f));

        mesh.vertices = vertices;

        mesh.triangles = new int[] { 3, 0, 2, 1, 2, 3 };

        GetComponent<MeshRenderer>().material = mat;
        GetComponent<MeshFilter>().mesh = mesh;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {


            //Graphics.DrawMesh(Polies, Vector3.zero, Quaternion.identity, mat, 0);

            //var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;
            //Quaternion rotation = Quaternion.identity;

            //var newPolies = Instantiate(Polygons);
            //Polies.Add(newPolies);


            
            //Instantiate(Polygons, Random.insideUnitSphere + transform.position, Random.rotation);
            //Instantiate(Polygons, Input.mousePosition, Quaternion.identity);
            Instantiate(Polygons, transform.position, Random.rotation);

        }



    }

}
