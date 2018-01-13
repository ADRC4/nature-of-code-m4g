using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkViz : MonoBehaviour {

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
        Neuron a = new Neuron(-2, 0);
        Neuron b = new Neuron(0, 0.75f);
        Neuron c = new Neuron(0, -0.75f);
        Neuron d = new Neuron(2, 0);

        // Connect them
        network.Connect(a, b, w);
        network.Connect(a, c, w);
        network.Connect(b, d, w);
        network.Connect(c, d, w);

        // Add them to the Network
        network.AddNeuron(a);
        network.AddNeuron(b);
        network.AddNeuron(c);
        network.AddNeuron(d);
    }

    void OnDrawGizmos()
    {
        
        // Draw the Network
        network.Display();
        //noLoop();
    }

}
