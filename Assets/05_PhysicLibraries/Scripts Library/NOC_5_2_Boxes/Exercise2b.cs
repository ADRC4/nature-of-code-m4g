﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Exercise_5_2 : MonoBehaviour
{
    public GameObject Box;
    public GameObject Platform;
    public static List<GameObject> Boxes = new List<GameObject>();
    public GravityBox gb;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;
            Quaternion rotation = Quaternion.identity;

            var newBox = Instantiate(Box, pos, rotation);
            Boxes.Add(newBox);
            gb.Move(Boxes);
        }
    }
}
