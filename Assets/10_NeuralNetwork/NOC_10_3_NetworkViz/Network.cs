using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Network
{
    // The Network has a list of neurons
    public List<Neuron> neurons;
    public PVector position;

    public Network(float x, float y)
    {
        position = new PVector(x, y);
        neurons = new List<Neuron>();
    }

    // We can add a Neuron
    public void AddNeuron(Neuron n)
    {
        neurons.Add(n);
    }

    // We can connection two Neurons
    public void Connect(Neuron a, Neuron b)
    {
        Connection c = new Connection(a, b, Random.Range(0.0f,0.5f));
        a.AddConnection(c);
    }

    // We can draw the network
    public void Display()
    {
        //GL.PushMatrix();
        //translate(position.x, position.y);
        foreach (Neuron n in neurons)
        {
            n.Display();
        }
        //GL.PopMatrix();

    }
}
