using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour {


    // Connection is from Neuron A to B
    Neuron a;
    Neuron b;

    // Connection has a weight
    float weight;

    Connection(Neuron from, Neuron to, float w)
    {
        weight = w;
        a = from;
        b = to;
    }

    // Drawn as a line
    void display()
    {
        stroke(0);
        strokeWeight(weight * 4);
        line(a.position.x, a.position.y, b.position.x, b.position.y);
    }
}
