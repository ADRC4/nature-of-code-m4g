﻿using UnityEngine;
using System.Collections;

public class SimplePerceptronP2 : MonoBehaviour
{

    Perceptron ptron;

    //2,000 training points
    //training is the point variable in the video tutorial
    Trainer[] training = new Trainer[2000];
    int count = 0;

    //The formula for a line
    float f(float x)
    {
        return 0.3f * x + 0.2f;
    }

    public float width = 4;
    public float height = 4;

    void Start()
    {
        ptron = new Perceptron(3);

        //Make 2,000 training points.
        for (int i = 0; i < training.Length; i++)
        {
            float x = Random.Range(-width / 2, width / 2);
            float y = Random.Range(-height / 2, height / 2);
            //Is the correct answer 1 or -1?
            int answer = 1;
            if (y < f(x)) answer = -1;
            training[i] = new Trainer(x, y, answer);
        }
    }


    void Update()
    {
        ptron.Train(training[count].inputs, training[count].answer);
        //For animation, we are training one point at a time.
        count = (count + 1) % training.Length;


    }

    void OnDrawGizmos()
    {
        for (int i = 0; i < count; i++)
        {
            int guess = ptron.Feedforward(training[i].inputs);
            //Show the classification—no fill for -1, black for +1.
            Color col = Color.blue;
            if (guess > 0) col = Color.blue;
            else col = Color.red;            
            
            //Draw seperation line
            var p1 = new Vector3(-width / 2, f(-height / 2), 0);
            var p2 = new Vector3(width / 2, f(height / 2), 0);
            Gizmos.DrawLine(p1, p2);

            //Draw Perceptron seperation line
            var p3 = new Vector3(-width / 2, ptron.GuessY(-width / 2), 0);
            var p4 = new Vector3(width / 2, ptron.GuessY(width / 2), 0);
            Gizmos.DrawLine(p3, p4);

            // Draw result
            Gizmos.color = col;
            Gizmos.DrawWireSphere(new Vector3(training[i].inputs[0], training[i].inputs[1], 0), .05f);
            
        }
    }
}