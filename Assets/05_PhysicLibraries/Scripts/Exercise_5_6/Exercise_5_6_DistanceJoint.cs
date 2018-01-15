using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise_5_6_DistanceJoint : MonoBehaviour
{

    public GameObject NO1;
    public GameObject NO2;
    //public void AddForce(Vector3 force, ForceMode mode = ForceMode.Force);

    public float thrust;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.up * thrust);
    }

    void Update()
    {

    }
}
