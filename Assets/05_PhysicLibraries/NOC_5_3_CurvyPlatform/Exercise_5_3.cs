using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise_5_3 : MonoBehaviour {

    public GameObject Box;
    public GameObject Platform;
    public static List<GameObject> BOXES = new List<GameObject>();

    void Start()
    {
        Physics.gravity = new Vector3(0, -1.0F, 0);
    }

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
