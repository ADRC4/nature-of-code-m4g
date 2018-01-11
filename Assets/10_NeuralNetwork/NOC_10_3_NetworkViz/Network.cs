using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Network
{
    // The Network has a list of neurons
    public List<Neuron> neurons;

    // The Network now keeps a duplicate list of all Connection objects.
    // This makes it easier to draw everything in this class
    public List<Connection> connections;
    public Vector2 position;

    // To translate PushMatrix and PopMatrix in Processing
    public Stack<TransformMatrix> TransformStack = new Stack<TransformMatrix>();

    public Network(float x, float y)
    {
        position = new Vector2(x, y);
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

    public void Feedforward2(float input)
    {
        Neuron start = neurons[1];
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
       // TransformMatrix TM = new TransformMatrix();
       // TM.position = new Vector3(position.x, position.y, 0);

       // TransformStack.Push(TM);
       // TM.position = new Vector3(position.x,position.y,0);        
        foreach (Neuron n in neurons)
        {
            n.Display();
        }

        foreach (Connection c in connections)
        {
            c.Display();
        }

       // TransformStack.Pop();    
    }
}
