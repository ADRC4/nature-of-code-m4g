using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle
{
    // Vehicle now has a brain!
    Perceptron2 brain;


    PVector position;
    PVector velocity;
    PVector acceleration;
    PVector desired;

    float r;
    float maxforce;    // Maximum steering force
    float maxspeed;    // Maximum speed

    public Vehicle(int n, float x, float y)
    {
        brain = new Perceptron2(n, 0.001f);
        acceleration = new PVector(0, 0);
        velocity = new PVector(0, 0);
        position = new PVector(x, y);
        r = 3.0f;
        maxspeed = 4;
        maxforce = 0.1f;
    }

    // Method to update position
    public void Update()
    {
        // Update velocity
        velocity.add(acceleration);
        // Limit speed
        //velocity.limit(maxspeed);
        position.add(velocity);
        // Reset accelerationelertion to 0 each cycle
        acceleration.mult(0);

        if (position.x > 0 && position.x < Screen.width)
        {
            this.position.x = position.x;
        }

        if(position.y > 0 && position.y < Screen.height)
        {
            this.position.y = position.y;
        }

        //position.x = constrain(position.x, 0, Screen.width);
        //position.y = constrain(position.y, 0, Screen.height);
    }

    public void ApplyForce(PVector force)
    {
        // We could add mass here if we want A = F / M
        acceleration.add(force);
    }

    // Here is where the brain processes everything
    public void steer(List<PVector> targets)
    {
        // Make an array of forces
        PVector[] forces = new PVector[targets.Count]; ///// ----- what is size of arraylist

        // Steer towards all targets
        for (int i = 0; i < forces.Length; i++)
        {
            forces[i] = seek(targets[i]); ////-------????
        }

        // That array of forces is the input to the brain
        PVector result = brain.feedforward(forces);

        // Use the result to steer the vehicle
        ApplyForce(result);

        // Train the brain according to the error
        PVector error = PVector.sub2(desired, position);
        brain.train(forces, error);

    }

    // A method that calculates a steering force towards a target
    // STEER = DESIRED MINUS VELOCITY
    PVector seek(PVector target)
    {
        PVector desired = PVector.sub2(target, position);  // A vector pointing from the position to the target

        // Normalize desired and scale to maximum speed
        desired.normalize();
        desired.mult(maxspeed);
        // Steering = Desired minus velocity
        PVector steer = PVector.sub2(desired, velocity);
        //steer.limit(maxforce);  // Limit to maximum steering force

        return steer;
    }

    /*public void Display () //////------?????
    {

        // Draw a triangle rotated in the direction of velocity
        float theta = velocity.heading2D() + Mathf.PI / 2;

        Color color = Color.green;

        //stroke(0);
        //strokeWeight(1);

        pushMatrix();

        translate(position.x, position.y);
        rotate(theta);

        beginShape();
        vertex(0, -r * 2);
        vertex(-r, r * 2);    /////---- draw triangle
        vertex(r, r * 2);
        endShape(CLOSE);

        popMatrix();
    }*/



    /*void OnDrawGizmos()
    {
        for (int i = 0; i < count; i++)
        {
            int guess = ptron.feedforward(training[i].inputs);
            //Show the classification—no fill for -1, black for +1.
            Color col = Color.blue;
            if (guess > 0) col = Color.blue;
            else col = Color.red;

            //Draw seperation line
            var p1 = new Vector3(-m_Width / 2, f(-m_Height / 2), 0);
            var p2 = new Vector3(m_Width / 2, f(m_Height / 2), 0);
            Gizmos.DrawLine(p1, p2);

            //Draw Perceptron seperation line
            var p3 = new Vector3(-m_Width / 2, ptron.guessY(-m_Width / 2), 0);
            var p4 = new Vector3(m_Width / 2, ptron.guessY(m_Width / 2), 0);
            Gizmos.DrawLine(p3, p4);

            // Draw result
            Gizmos.color = col;
            Gizmos.DrawWireSphere(new Vector3(training[i].inputs[0], training[i].inputs[1], 0), .05f);

        }
    }*/
}
