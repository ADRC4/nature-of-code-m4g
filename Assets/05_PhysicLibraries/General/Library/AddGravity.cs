using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGravity : MonoBehaviour
{
	void Start ()
    {
        Physics.gravity = new Vector3(0, -1.0F, 0);
    }
}
