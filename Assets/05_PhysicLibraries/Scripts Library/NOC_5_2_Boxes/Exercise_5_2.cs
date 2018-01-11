using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exercise2b : MonoBehaviour
{
    public GameObject Box;
    public GameObject Platform;
    public static List<GameObject> Boxes = new List<GameObject>();

    //void Start()
    //{
    //    Physics.gravity = new Vector3(0, -1.0F, 0);
    //}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;
            Quaternion rotation = Quaternion.identity;

            var newBox = Instantiate(Box, pos, rotation);
            Boxes.Add(newBox);

            //if(Platform)
        }
    }
}
