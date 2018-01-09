using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Network
{
    // The Network has a list of neurons
    public List<Neuron> neurons;
    public List<Connection> connections;
    public PVector position;

    public Network(float x, float y)
    {
        position = new PVector(x, y);
        neurons = new List<Neuron>();
        connections = new List<Connection>();
    }

    // We can add a Neuron
    public void AddNeuron(Neuron n)
    {
        neurons.Add(n);
    }

    // We can connection two Neurons
    public void Connect(Neuron a, Neuron b, float weight)
    {
        Connection c = new Connection(a, b, weight);
        a.AddConnection(c);
        //Also add the Connection here
        connections.Add(c);

    }

    //Sending an input to the first Neuron
    //We should do something better to track multiple inputs
    public void Feedforward(float input)
    {
        Neuron start = neurons[0];
        start.Feedforward(input);
    }

    // Update the animation

    public void Update()
    {
        foreach (Connection c in connections)
        {
            c.Update();
        }
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
        foreach (Connection c in connections)
        {
            c.Display();
        }
        //GL.PopMatrix();
    }
}
