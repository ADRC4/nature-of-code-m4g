using UnityEngine;
using System.Collections;

public class Perceptron
{

    //The Perceptron stores its weights and learning constants.
    float[] weights;
    //Learning Constant
    float c = 0.01f;

    //Constructor
    public Perceptron(int n)
    {
        weights = new float[n];

        //Weights start off random.
        for (int i = 0; i < weights.Length; i++)
        {
            weights[i] = Random.Range(-1f, 1f);
        }
    }

    //Return an output based on inputs.
    public int feedforward(float[] inputs)
    {
        float sum = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            sum += inputs[i] * weights[i];
        }
        return activate(sum);
    }

    //Output is a +1 or -1.
    public int activate(float sum)
    {
        if (sum > 0) return 1;
        else return -1;
    }

    //Train the network against known data.
    public void train(float[] inputs, int desired)
    {
        int guess = feedforward(inputs);
        float error = desired - guess;
        for (int i = 0; i < weights.Length; i++)
        {
            weights[i] += c * error * inputs[i];
        }
    }

    public float guessY(float x)
    {
        float w0 = weights[0];
        float w1 = weights[1];
        float w2 = weights[2];

        return -(w2 / w1) - (w0 / w1) * x;
    }
}
