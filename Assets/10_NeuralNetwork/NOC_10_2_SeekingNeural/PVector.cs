using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PVector
{

    float x;
    float y;

    public PVector(float x_, float y_)
    {
        x = x_;
        y = y_;
    }

    public void add(PVector v)
    {

        y = y + v.y;

        x = x + v.x;
    }

    public void sub(PVector v)
    {

        y = y - v.y;

        x = x - v.x;
    }

    public void mult(float n)
    {
        x = x * n;
        y = y * n;
    }

    public void div (float n)
    {
        x = x / n;
        y = y / n;
    }

    public float mag()
    {
        return sqrt(x * x + y * y);
    }

    public void normalize()
    {
        float m = mag();
        if (m != 0)
        {
            div(m);
        }
    }

}


