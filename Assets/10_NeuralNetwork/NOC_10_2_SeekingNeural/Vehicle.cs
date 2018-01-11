using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle: MonoBehaviour
{
    // Vehicle now has a brain!
    Perceptron2 brain;
    public Mesh vehicleMesh;

    Vector2 position;
    Vector2 velocity;
    Vector2 acceleration;
    Vector2 desired;
    Vector2 target;

    float r;
    float maxforce;    // Maximum steering force
    float maxspeed;    // Maximum speed

    public Vehicle(int n, float x, float y)
    {
        brain = new Perceptron2(n, 0.001f);
        acceleration = new Vector2(0, 0);
        velocity = new Vector2(0, 0);
        position = new Vector2(x, y);
        r = 3.0f;
        maxspeed = 4;
        maxforce = 0.1f;
    }

    // Method to update position
    public void Update()
    {
        Vector2 velocity = Vector2.zero;
        Vector2 acceleration = Vector2.zero;
        Vector2 position = Vector2.zero;
        
        velocity += acceleration;
        // Update velocity
        //velocity.Add(acceleration);
        // Limit speed

        if(velocity.magnitude > maxspeed)
        {
            velocity = velocity.normalized * maxspeed;
        }

        //velocity.limit(maxspeed);

        position += velocity;
        //position.add(velocity);
        // Reset accelerationelertion to 0 each cycle
        //acceleration.mult(0);

        acceleration *= 0;

        if (position.x > 0 && position.x < Screen.width)
        {
            this.position.x = position.x;
        }

        if (position.y > 0 && position.y < Screen.width)
        {
            this.position.y = position.y;
        }

        //position.x = constrain(position.x, 0, Screen.width);
        //position.y = constrain(position.y, 0, Screen.height);
    }

    public void ApplyForce(Vector2 force)
    {
        // We could add mass here if we want A = F / M
        //acceleration.add(force);
        acceleration += force;
    }

    // Here is where the brain processes everything
    public void steer(List<Vector2> targets)
    {
        
        // Make an array of forces
        Vector2[] forces = new Vector2[targets.Count]; ///// ----- what is size of arraylist

        // Steer towards all targets
        for (int i = 0; i < forces.Length; i++)
        {
            forces[i] = seek(targets[i]); ////-------????
        }

        // That array of forces is the input to the brain
        Vector2 result = brain.feedforward(forces);

        // Use the result to steer the vehicle
        ApplyForce(result);

        // Train the brain according to the error
        Vector2 error = new Vector2 (desired.x - position.x, desired.y - position.y);
        brain.train(forces, error);

    }

    // A method that calculates a steering force towards a target
    // STEER = DESIRED MINUS VELOCITY
    Vector2 seek(Vector2 target)
    {
        Vector2 desired = new Vector2(target.x - position.x, target.y - position.y);  // A vector pointing from the position to the target

        // Normalize desired and scale to maximum speed
        desired.Normalize();
        //desired.mult(maxspeed);
        desired *= maxspeed;
        // Steering = Desired minus velocity
        Vector2 steer = new Vector2 (desired.x - velocity.x, desired.y - velocity.y);
        if(steer.magnitude > maxspeed)
        {
            steer = steer.normalized * maxspeed;
        }
        //steer.limit(maxforce);  // Limit to maximum steering force

        return steer;
    }

    public void Display() //////------?????
    {

        // Draw a triangle rotated in the direction of velocity
        //float theta = velocity.heading2D() + Mathf.PI / 2;

        Color color = Color.green;

        Gizmos.DrawSphere(new Vector2(position.x,position.y), 0.1f);

        //stroke(0);
        //strokeWeight(1);

        //pushMatrix();
        //translate(position.x, position.y);
        //rotate(theta);
        //beginShape();
        //vertex(0, -r * 2);
        //vertex(-r, r * 2);
        //vertex(r, r * 2);
        //endShape(CLOSE);
        //popMatrix();
    }

}
