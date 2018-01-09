using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PVector
{

    public float x;
    public float y;

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

    public void sub2(PVector v, PVector w) ///----- 2 arguments
    {
        x = v.x - w.x;
        y = v.y - w.y;
        
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
        return Mathf.Sqrt(x * x + y * y);
    }

    public void normalize()
    {
        float m = mag();
        if (m != 0)
        {
            div(m);
        }
    }
    
    //public void limit(float f)
    //{
    //    if ((double)this.sqrMagnitude > (double)f * (double)f)
    //        this.set(this.normalized * f);
    //}


}


