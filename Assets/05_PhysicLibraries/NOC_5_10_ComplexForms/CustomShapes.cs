﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomShapes : MonoBehaviour
{

    public float worldAxisAlignedBoundingBoxLowerBoundDefault = -100f;
    public float worldAxisAlignedBoundingBoxUpperBoundDefault = 100f;

    public float gravity = 9.8f; // m / s^2

    public int velocityIterations = 8;
    public int positionIteration = 1;

    public GameObject Polygons;
    public static List<GameObject> Polies = new List<GameObject>();

    public Material mat;

    float width = 1;
    float height = 1;
    Vector3 firstObjPos;

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
            //Instantiate(Polygons, transform.position, Random.rotation);
            //Instantiate(Polygons, new Vector3(0.7f, 3.9f, -4), transform.rotation);


            Vector3 position = new Vector3(Random.Range(0.15F, 1.0F), Random.Range(-0.15F, 1.0F), Random.Range(-0.15F, 1.0F));

           
            Instantiate(Polygons, position + firstObjPos, Quaternion.identity);
        }



    }

}
