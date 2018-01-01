using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point
{
    float x;
    float y;
    int label;
    Color color;

    public void Points()
    {
        x = Random.Range(0,Screen.width/4);
        y = Random.Range(0, Screen.height/4);

        if (x < y) label = 1;
        else label = -1;
    }

    public void Show()
    {
        if (label == 1)
        {
            color = Color.green;
        }
        else
        {
            color = Color.red;
        }
    }
}
