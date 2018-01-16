using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise_5_1 : MonoBehaviour
{
    public GameObject Box;
    public static List<GameObject> BOXES = new List<GameObject>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;
            Quaternion rotation = Quaternion.identity;

            var newBox = Instantiate(Box, pos, rotation);
            Rigidbody gameObjectsRigidBody = newBox.AddComponent<Rigidbody>();
            BOXES.Add(newBox);
        }
    }
}