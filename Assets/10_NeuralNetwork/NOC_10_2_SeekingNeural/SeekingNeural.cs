//using UnityEngine;
//using System.Collections;

//public class SeekingNeural : MonoBehaviour
//{
//    Vehicle v;

//    PVector desired;

//    PVector[] targets;

//    void setup()
//    {
//        size(640, 360);
//        // The Vehicle's desired position
//        desired = new PVector(Screen.width / 2, Screen.height / 2);


//        // Create a list of targets
//        makeTargets();

//        // Create the Vehicle (it has to know about the number of targets
//        // in order to configure its brain)
//        v = new Vehicle(targets.Length(), Random.Range(0,Screen.width), Random.Range(0,Screen.height));
//    }

//    // Make a random ArrayList of targets to steer towards
//    void makeTargets()
//    {
//        targets = new PVector[i];
//        for (int i = 0; i < 8; i++)
//        {
//            targets.add(new PVector(Random.Range(0, Screen.width), Random.Range(0, Screen.height)));
//        }
//    }

//    void OnDrawGizmos ()
//    {
//        //background(255);

//        // Draw a circle to show the Vehicle's goal
//        //stroke(0);
//        //strokeWeight(2);
//        //fill(0, 100);
//        //ellipse(desired.x, desired.y, 36, 36);

//        Gizmos.color = Color.blue;
//        Gizmos.DrawWireSphere(new Vector3(desired.x, desired.y, 0), 0.3f);

//        // Draw the targets
//        foreach (PVector[] target in targets)
//        {
//            //noFill();
//            //stroke(0);
//            //strokeWeight(2);

//            Gizmos.DrawWireSphere(new Vector3(target.x, target.y, 0), 0.1f);


//            var p1 = new Vector3 (target.x, target.y - 16, 0);
//            var p2 = new Vector3 (target.x - 16, target.y, 0);
//            Gizmos.DrawLine(p1, p2);



//            //ellipse(target.x, target.y, 16, 16);
//            //line(target.x, target.y - 16, target.x, target.y + 16);
//            //line(target.x - 16, target.y, target.x + 16, target.y);
//        }

//        // Update the Vehicle
//        v.steer(targets);
//        v.Update();
//        v.Display();
//    }

//    void OnMouseButton()
//    {
//        makeTargets();
//    }

//}