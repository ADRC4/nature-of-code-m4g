using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkViz : MonoBehaviour {

    Network network;
    public float width = 6.4f;
    public float height = 3.6f;

    void Start()
    {
        
        // Create the Network object
        network = new Network(width / 2, height / 2);

        // Create a bunch of Neurons
        Neuron a = new Neuron(-200, 0);
        Neuron b = new Neuron(0, 75);
        Neuron c = new Neuron(0, -75);
        Neuron d = new Neuron(200, 0);

        // Connect them
        network.connect(a, b);
        network.connect(a, c);
        network.connect(b, d);
        network.connect(c, d);

        // Add them to the Network
        network.addNeuron(a);
        network.addNeuron(b);
        network.addNeuron(c);
        network.addNeuron(d);
    }

    void OnDrawGizmos()
    {
        //background(255);
        // Draw the Network
        network.display();
        noLoop();
    }
}
