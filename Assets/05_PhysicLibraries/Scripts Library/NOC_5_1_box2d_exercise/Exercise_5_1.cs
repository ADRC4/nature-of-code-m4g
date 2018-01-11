using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise_5_1 : MonoBehaviour {

    public GameObject Box;
    public static List<GameObject> Boxes = new List<GameObject>();
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var newBox = Instantiate(Box);
            Boxes.Add(newBox);
        }
      
    }
}






