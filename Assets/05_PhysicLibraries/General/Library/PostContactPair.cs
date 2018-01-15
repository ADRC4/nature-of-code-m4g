using UnityEngine;
using System.Collections;
using Box2DX.Dynamics;

public struct PostContactPair
{
	public Contact 			contact;
	public ContactImpulse 	impulse;
}
	