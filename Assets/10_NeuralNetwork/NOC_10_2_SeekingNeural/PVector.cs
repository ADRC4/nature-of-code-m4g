using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PVector
{
    public float x { set; get; }
    public float y { set; get; }

    public PVector()
    {
        this.x = 0;
        this.y = 0;
    }

    public PVector(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public void add(PVector v)
    {
        x += v.x;
        y += v.y;
    }

    public void add2(PVector v, PVector w)
    {
        x = v.x + w.x;
        y = v.y + w.y;
    }

    public void sub(PVector v)
    {
        x = x - v.x;
        y = y - v.y;
    }

    public void sub2(PVector v, PVector w)
    {
        x = v.x - w.x;
        y = v.y - w.y;
    }

    public void mult(float n)
    {

        x = x * n;
        y = y * n;

    }
    public void limit(float f)
    {


        if ((double)this.sqrMagnitude > (double)f * (double)f)
            this.set(this.normalized * f);


    }
    public void normalize()
    {
        float magnitude = this.magnitude;
        if ((double)magnitude > 9.99999974737875E-06)
            this.set(this / magnitude);
        else
        {
            this.x = 0;
            this.y = 0;
        }
    }

    public PVector normalized
    {
        get
        {
            PVector PVector = new PVector(this.x, this.y);
            PVector.normalize();
            return PVector;
        }
    }

    public void set(PVector v)
    {
        x = v.x;
        y = v.y;
    }

    public float magnitude
    {
        get
        {
            return Mathf.Sqrt((float)((double)this.x * (double)this.x + (double)this.y * (double)this.y));
        }
    }

    public float sqrMagnitude
    {
        get
        {
            return (float)((double)this.x * (double)this.x + (double)this.y * (double)this.y);
        }
    }

    public static PVector operator /(PVector a, float d)
    {
        return new PVector(a.x / d, a.y / d);
    }

    public static PVector operator +(PVector a, PVector b)
    {
        return new PVector(a.x + b.x, a.y + b.y);
    }

    public static PVector operator *(PVector a, float d)
    {
        return new PVector(a.x * d, a.y * d);
    }


    public static implicit operator Vector3(PVector v)
    {
        return new Vector3(v.x, v.y, 0.0f);
    }

}


