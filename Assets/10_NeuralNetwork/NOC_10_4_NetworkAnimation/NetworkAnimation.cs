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
        Application.targetFrameRate = 60;
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
        network.Connect(a, b, 1);
        network.Connect(b, c, Random.value);
        network.Connect(b, d, Random.value);
        network.Connect(c, e, Random.value);
        network.Connect(d, e, Random.value);
        network.Connect(e, f, 1);

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
        if (network == null) return;        
        // Update and display the Network
            network.Update();
            network.Display();

        ////Every 30 frame feed an Input
        if (Time.frameCount % 30 == 0)
            network.Feedforward(Random.value, 0);

    }

}
