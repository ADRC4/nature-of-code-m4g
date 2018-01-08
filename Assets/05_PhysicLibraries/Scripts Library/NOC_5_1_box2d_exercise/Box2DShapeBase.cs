using UnityEngine;
using System.Collections;
using Box2DX.Dynamics;

public abstract class Box2DShapeBase : MonoBehaviour {
	
	public abstract FixtureDef ToFixtureDef();
	
}
