using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perceptron
{
    //The activation function
    public int sign(float n)
    {
        if (n > 0) return 1;
        else return -1;
    }

    float[] weights = new float[2];  
    
    //Constructor
    public void Percetron()
    {
        //Initialize the weights randomly
        for (int i = 0; i < weights.Length; i++)
        {
            weights[i] = Random.Range(-1, 1);
        }
        
    }
    
    public int guess (float[] inputs)
    {
        float sum = 0;
        for (int i = 0; i < weights.Length ; i++)
        {
            sum += inputs[i] * weights[i];
        }

        int output = sign(sum);
        return output;
    }
}
