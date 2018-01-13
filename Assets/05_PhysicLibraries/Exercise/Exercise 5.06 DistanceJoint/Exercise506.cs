using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exercise506 : MonoBehaviour
{
    public GameObject Box;
    public static List<GameObject> Boxes = new List<GameObject>();
    //private float _x;
    //private float _y;

    void Start()
    {
        Physics.gravity = new Vector3(0, -1.0F, 0);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // RaycastHit hit;
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;
            Quaternion rotation = Quaternion.identity;

            var newBox = Instantiate(Box, pos, rotation);
            Boxes.Add(newBox);

        }
    }

}
