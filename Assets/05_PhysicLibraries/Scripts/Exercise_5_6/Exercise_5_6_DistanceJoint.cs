using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise_5_6_DistanceJoint : MonoBehaviour
{
    public GameObject NO1;
    public GameObject NO2;
    public HingeJoint[] hingeJoints;

    void Start()
    {
        Physics.gravity = new Vector3(0, -1.0F, 0);
    }

    void Update()
    {
        hingeJoints = GetComponents<HingeJoint>(NO1 ,NO2 );
        foreach (HingeJoint joint in hingeJoints)
        {
            joint.useSpring = false;
        }

        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;
        Quaternion rotation = Quaternion.identity;

        var _NO1 = Instantiate(NO1, pos, rotation);
        Rigidbody gameObjectsRigidBody = _NO1.AddComponent<Rigidbody>();
        var _NO2 = Instantiate(NO2, pos, rotation);
        Rigidbody _gameObjectsRigidBody = _NO2.AddComponent<Rigidbody>();
    }

    private T[] GetComponents<T>(GameObject nO1, GameObject nO2)
    {
        throw new NotImplementedException();
    }
}
