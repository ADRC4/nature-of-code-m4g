using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkAnimation1 : MonoBehaviour
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
        Neuron a = new Neuron(-3f, 0.75f);
        Neuron b = new Neuron(-3f, -0.75f);
        Neuron c = new Neuron(-1.0f, 0.75f);
        Neuron d = new Neuron(-1.0f, -0.75f);
        Neuron e = new Neuron(1.0f, 0.75f);
        Neuron f = new Neuron(1.0f, -0.75f);
        Neuron g = new Neuron(3f, 0);

        // Connect them
        network.Connect(a, c, w);
        network.Connect(a, d, w);
        network.Connect(b, c, w);
        network.Connect(b, d, w);
        network.Connect(c, e, w);
        network.Connect(c, f, w);
        network.Connect(d, e, w);
        network.Connect(d, f, w);
        network.Connect(e, g, w);
        network.Connect(f, g, w);

        // Add them to the Network
        network.AddNeuron(a);
        network.AddNeuron(b);
        network.AddNeuron(c);
        network.AddNeuron(d);
        network.AddNeuron(e);
        network.AddNeuron(f);
        network.AddNeuron(g);
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
        int n = network.neurons.Count;
        for (int i = 0; i < n; i++)
        {
            if (Time.renderedFrameCount % (n*10) == (i*10))
                network.Feedforward(Random.value, i);
        }

    }

}
