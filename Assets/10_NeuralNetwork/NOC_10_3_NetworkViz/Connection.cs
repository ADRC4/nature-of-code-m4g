using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection
{
    // Connection is from Neuron A to B
    Neuron a;
    Neuron b;

    // Connection has a weight
    float weight;

    public Connection(Neuron from, Neuron to, float w)
    {
        weight = w;
        a = from;
        b = to;
    }

    // Drawn as a line
    public void Display()
    {
        float strokeWeight = weight * 4;
        Gizmos.DrawLine(new Vector3(a.position.x, a.position.y,0), new Vector3(b.position.x, b.position.y,0));
    }
}
