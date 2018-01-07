using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perceptron2
{
    float[] weights;  // Array of weights for inputs
    float c;          // learning constant

    // Perceptron is created with n weights and learning constant
    public void perceptron2(int n, float c_)
    {
        weights = new float[n];
        c = c_;
        // Start with random weights
        for (int i = 0; i < weights.Length; i++)
        {
            weights[i] = Random.Range(0, 1);
        }
    }

    // Function to train the Perceptron
    // Weights are adjusted based on vehicle's error
    void train(PVector[] forces, PVector error)
    {
        for (int i = 0; i < weights.Length; i++)
        {
            weights[i] += c * error.x * forces[i].x;
            weights[i] += c * error.y * forces[i].y;
            weights[i] = constrain(weights[i], 0, 1);
        }
    }

    // Give me a steering result
    public PVector feedforward(PVector[] forces)
    {
        // Sum all values
        PVector sum = new PVector();
        for (int i = 0; i < weights.Length; i++)
        {
            forces[i].mult(weights[i]);
            sum.add(forces[i]);
        }
        return sum;
    }
}
