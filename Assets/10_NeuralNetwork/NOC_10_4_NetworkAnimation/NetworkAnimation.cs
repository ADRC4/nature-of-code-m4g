using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkAnimation : MonoBehaviour
{
    Network network;
    public float width = 6.4f;
    public float height = 3.6f;
    float w;

    void Start()
    {
        w = Random.Range(0.0f, 0.5f);
        // Create the Network object
        network = new Network(width / 2, height / 2);

        // Create a bunch of Neurons
        Neuron a = new Neuron(-2.75f, 0);
        Neuron b = new Neuron(-1.5f, 0);
        Neuron c = new Neuron(0, 0.75f);
        Neuron d = new Neuron(0, -0.75f);
        Neuron e = new Neuron(1.5f, 0);
        Neuron f = new Neuron(2.75f, 0);

        // Connect them
        network.Connect(a, b, 0);
        network.Connect(b, c, w);
        network.Connect(b, d, w);
        network.Connect(c, e, w);
        network.Connect(d, e, w);
        network.Connect(e, f, 0);

        // Add them to the Network
        network.AddNeuron(a);
        network.AddNeuron(b);
        network.AddNeuron(c);
        network.AddNeuron(d);
        network.AddNeuron(e);
        network.AddNeuron(f);
    }

    void OnDrawGizmos()
    {
        while (true)
        {// Update and display the Network
            network.Update();
            network.Display();
            break;
        }

        ////Every 100 frame feed an Input
        if (Time.renderedFrameCount % 100 == 0)
            network.Feedforward(Random.value);   
    }

}
