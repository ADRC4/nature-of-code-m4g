using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise2a : MonoBehaviour {

    public GameObject Box;
    public static List<GameObject> Boxes = new List<GameObject>();
    private float _x;
    private float _y;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var newBox = Instantiate(Box);
            Boxes.Add(newBox);
        }
    }
}






