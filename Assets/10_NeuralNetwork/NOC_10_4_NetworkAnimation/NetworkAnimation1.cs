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
        Application.targetFrameRate = 60;
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
        if (network == null) return;
        // Update and display the Network
        network.Update();
            network.Display();

        ////Every 30 frame feed an Input

        if (Time.frameCount % 30 == 0)
        {
            network.Feedforward(Random.value, 0);
            network.Feedforward(Random.value, 1);
        }

    }

}
