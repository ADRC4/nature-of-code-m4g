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

    //Variable to track the animation
    bool sending = false;
    Vector2 sender;

    // Need to store the output for when its time to pass along
    float output = 0;

    public Connection(Neuron from, Neuron to, float w)
    {
        weight = w;
        a = from;
        b = to;
    }

    // The Connection is active
    public void Feedforward(float val)
    {
        output = val * weight;  // Compute output
        sender = a.position;    // Start animation at Neuron A
        sending = true;         // Turn on sending
    }

    // Update traveling sender
    public void Update()
    {
        if (sending)
        {
            // Use a simple interpolation
            sender.x = Mathf.Lerp(sender.x, b.position.x, 0.015f);
            sender.y = Mathf.Lerp(sender.y, b.position.y, 0.015f);
        }

        float d = Vector2.Distance(new Vector2 (sender.x,sender.y), new Vector2( b.position.x, b.position.y));

        // If we've reach the end
        if (d < 0.01f)
        {
            b.Feedforward(output);
            sending = false;
        }
    }

    // Drawn as a line and Traveling circle
    public void Display()
    {

        Gizmos.color = Color.HSVToRGB(0, 0, weight);
        Gizmos.DrawLine(new Vector3(a.position.x, a.position.y, 0), new Vector3(b.position.x, b.position.y, 0));

        if (sending)
        {
            Gizmos.DrawSphere(new Vector3(sender.x, sender.y, 0), 0.05f);
        }
    }
}
