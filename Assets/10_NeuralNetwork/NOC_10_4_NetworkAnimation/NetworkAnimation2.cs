using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkAnimation2 : MonoBehaviour
{
    Network network;
    public float width = 10f;
    public float height = 5f;    
    public int inputNeuron = 5;
    public int firstHidenNeuron = 7;
    public int secondHidenNeuron = 7;
    public int outputNeuron = 3;
    public float gap = 0.75f;
    public float gap1 = 0.5f;

    public Neuron[] inputNeurons;
    public Neuron[] firstHidenNeurons;
    public Neuron[] secondHidenNeurons;
    public Neuron[] outputNeurons = new Neuron[3];

    void Start()
    {
        inputNeurons = new Neuron[inputNeuron];
        firstHidenNeurons = new Neuron[firstHidenNeuron];
        secondHidenNeurons = new Neuron[secondHidenNeuron];
        outputNeurons = new Neuron[outputNeuron];


        Application.targetFrameRate = 60;        
        // Create the Network object
        network = new Network(width / 2, height / 2);

        Neuron tile = new Neuron(-4, 0);

        // Create input neurons
        for (int i = 0; i < inputNeuron; i++)        
            inputNeurons[i] = new Neuron(-3f, i * gap - ((inputNeuron * gap)/2) + gap/2);        

        // Create first hidden neurons
        for (int j = 0; j < firstHidenNeuron; j++)        
            firstHidenNeurons[j] = new Neuron(-1f, j * gap - ((firstHidenNeuron * gap) / 2) + gap / 2);        

        // Create second hidden neurons
        for (int k = 0; k < secondHidenNeuron; k++)        
            secondHidenNeurons[k] = new Neuron(1f, k * gap1 - ((secondHidenNeuron * gap1) / 2) + gap1 / 2);        

        // Create output neurons
        for (int l = 0; l < outputNeuron; l++)        
            outputNeurons[l] = new Neuron(3f, l * gap - ((outputNeuron * gap) / 2) + gap / 2);

        Neuron final = new Neuron(4.5f, 0);


        // Connect them
        foreach (var input in inputNeurons)
            network.Connect(tile, input, 1);

        foreach (var input in inputNeurons)        
            foreach (var first in firstHidenNeurons)            
                network.Connect(input, first, Random.value);

        foreach (var first in firstHidenNeurons)
            foreach (var second in secondHidenNeurons)
                network.Connect(first, second, Random.value);

        foreach (var second in secondHidenNeurons)
            foreach (var output in outputNeurons)
                network.Connect(second, output, Random.value);

        foreach (var output in outputNeurons)
            network.Connect(output, final, 1);

        // Add them to the Network
        network.AddNeuron(tile);
        foreach (var input in inputNeurons) network.AddNeuron(input);
        foreach (var first in firstHidenNeurons) network.AddNeuron(first);
        foreach (var second in secondHidenNeurons) network.AddNeuron(second);
        foreach (var output in outputNeurons) network.AddNeuron(output);
        network.AddNeuron(final);
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
             network.Feedforward(Random.value,0);                
                                
        }

    }

}
