using Box2DX.Collision;
using Box2DX.Dynamics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Exercise2b : MonoBehaviour
{


    public GameObject Box;
    public GameObject Platform;
    public static List<GameObject> BOXES = new List<GameObject>();
    public float gravity = 9.8f;
    World _world;

    int Force;
    int Gravity;
    Boolean Falling;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;
            Quaternion rotation = Quaternion.identity;

            var newBox = Instantiate(Box, pos, rotation);
            BOXES.Add(newBox);
            //GravityBox_ _BOXES = new GravityBox_();
            //_BOXES.Move(BOXES);

            if (_world == null)
            {
                AABB BOXES = new AABB();
                _world = new World(BOXES, new Vector2(0f, -gravity), true);
            }
        }

    }

    //class GravityBox_
    //{
    //    private DateTime time;
    //    private bool falling = true;

    //    public float gravity = 9.8f;

    //    public void Move(List<GameObject> Boxes)
    //    {
    //        if (falling)
    //        {
    //            TimeSpan seconds = time - DateTime.Now;
    //            //double fall = 9.8 * (Math.Pow(seconds.TotalSeconds, 2));
    //            Physics.gravity = new Vector2(0f, -gravity);
    //        }
    //    }
    //}
}
