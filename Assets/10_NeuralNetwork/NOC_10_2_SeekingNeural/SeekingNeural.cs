using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SeekingNeural : MonoBehaviour
{
    Vehicle v;

    Vector2 desired;
    Vector3 target;

    List<Vector2> targets;
    public float width = 6.4f;
    public float height = 3.6f;

    void Start()
    {
        // The Vehicle's desired position
        desired = new Vector2(0, 0);

        // Create a list of targets
        MakeTargets();

        // Create the Vehicle (it has to know about the number of targets
        // in order to configure its brain)
        v = new Vehicle(targets.Count, Random.Range(0, width), Random.Range(0, height));
    }

    // Make a random ArrayList of targets to steer towards
    void MakeTargets()
    {
        targets = new List<Vector2>();
        for (int i = 0; i < 8; i++)
        {
            target = new Vector3 (Random.Range(0, width), Random.Range(0, height), 0);
            targets.Add(target);
        }
    }

    void OnDrawGizmos()
    {
        //background(255);

        // Draw a circle to show the Vehicle's goal
        //stroke(0);
        //strokeWeight(2);
        //fill(0, 100);
        //ellipse(desired.x, desired.y, 36, 36);

        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(new Vector3(desired.x, desired.y,0), new Vector3(0.6f,0.6f,0.6f));

        // Draw the targets
        foreach (Vector3 t in targets)
        {
            //noFill();
            //stroke(0);
            //strokeWeight(2);

            Gizmos.DrawWireSphere(new Vector3(target.x, target.y, 0), 0.2f);

            var p1 = new Vector3(target.x, target.y - 0.016f, 0);
            var p2 = new Vector3(target.x - 0.016f, target.y, 0);
            Gizmos.DrawLine(p1, p2);

            //ellipse(target.x, target.y, 16, 16);
            //line(target.x, target.y - 16, target.x, target.y + 16);
            //line(target.x - 16, target.y, target.x + 16, target.y);
        }

        // Update the Vehicle
        v.steer(targets);
        v.Update();
        v.Display();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MakeTargets();
        }
    }

}