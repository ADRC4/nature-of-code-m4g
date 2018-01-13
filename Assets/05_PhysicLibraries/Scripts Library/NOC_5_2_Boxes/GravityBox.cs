using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GravityBox : MonoBehaviour
{
    private DateTime time;
    private bool falling = true;

    public float gravity = 9.8f;

    public void Move(List<GameObject> Boxes)
    {
        //if (falling)
        //{
        //    TimeSpan seconds = time - DateTime.Now;
        //    //double fall = 9.8 * (Math.Pow(seconds.TotalSeconds, 2));
        //    Physics.gravity = new Vector2(0f, -gravity);
        //}

        TimeSpan seconds = time - DateTime.Now;
        //double fall = 9.8 * (Math.Pow(seconds.TotalSeconds, 2));
        Physics.gravity = new Vector2(0f, -gravity);
    }

}
