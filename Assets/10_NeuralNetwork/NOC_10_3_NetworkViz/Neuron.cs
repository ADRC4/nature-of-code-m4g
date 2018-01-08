using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neuron
{
    // Neuron has a position
    public PVector position;

    // Neuron has a list of connections    
    public List<Connection> connections;

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

    // Draw Neuron as a circle
    public void Display()
    {
        //stroke(0);
        //strokeWeight(1);
        //fill(0);
        //ellipse(position.x, position.y, 16, 16);
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(new Vector3(position.x, position.y, 0), .1f);

        // Draw all its connections
        foreach (Connection c in connections)
        {
            c.Display();
        }
    }
}
