using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neuron
{
    // Neuron has a position
    public PVector position;

    // Neuron has a list of connections    
    public List<Connection> connections;

    //We now track the inputs and sum them
    float sum = 0;

    //The Neuron's size can be animated
    float r = 0.1f;

    public Neuron(float x, float y)
    {
        position = new PVector(x, y);
        connections = new List<Connection>();
    }

    // Add a Connection
    public void AddConnection(Connection c)
    {
        connections.Add(c);
    }


    // Receive an input
    public void Feedforward(float input)
    {
        //Accumulate it
        sum += input;
        //Active it?
        if (sum > 1)
        {
            Fire();
            sum = 0; //Reset the sum to 0 if it fires
        }
    }

    //The Neuron Fire
    public void Fire()
    {
        r = 0.2f; //Neuron become bigger

        //We send the output through all connections
        foreach (Connection c in connections)
        {
            c.Feedforward(sum);
        }

    }

    // Draw Neuron as a circle
    public void Display()
    {
        //Brightness is mapped to sum
        float b = 255f;
        Gizmos.color = Color.HSVToRGB(0,0,b);

        Gizmos.DrawSphere(new Vector3(position.x, position.y, 0), r);

        //// Draw all its connections
        //foreach (Connection c in connections)
        //{
        //    c.Display();
        //}

        // Size shrinks down back to original dimensions
        r = Mathf.Lerp(r, 0.1f, 0.1f);
    }
}
