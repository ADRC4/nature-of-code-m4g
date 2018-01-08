using UnityEngine;
using System.Collections;
using Box2DX.Dynamics;

#if USING_BOX2DX
using Box2DX.Common;
#endif 

using Color = UnityEngine.Color;

[RequireComponent(typeof(Box2DBody))]
public class Box2DDistanceJoint : Box2DJoint<DistanceJoint> {
	
	public Box2DBody connectedBody;
	public Vector2 anchor;
	public Vector2 connectedAnchor;

	public float dampingRatio = 0f;
	public float frequencyHz = 0f;
	
	public bool collideConnected = false;
	
	public bool fixedLength = false;
	public float length = 1f;

	void Start() {
		if (connectedBody == null) {
			return;
		}
		var jointDef = new DistanceJointDef();
		jointDef.CollideConnected = collideConnected;
		
		if (fixedLength) { 
			jointDef.Body1 = GetComponent<Box2DBody>();
			jointDef.Body2 = connectedBody;
			jointDef.LocalAnchor1 = transform.InverseTransformPoint(anchor);
			jointDef.LocalAnchor2 = connectedBody.transform.InverseTransformPoint(connectedAnchor);
			jointDef.Length = length;
		} else { 
			jointDef.Initialize(GetComponent<Box2DBody>(), connectedBody, anchor, connectedAnchor);
		}
		jointDef.FrequencyHz = frequencyHz;
		jointDef.DampingRatio = dampingRatio;
		
		var world = Box2DWorld.Instance();
		joint = (DistanceJoint)world.CreateJoint(jointDef);
		
	}
	
	void Update() { 
		if (joint == null) { 
			return;
		}
		anchor = ((DistanceJoint)joint).Anchor1;
		connectedAnchor = ((DistanceJoint)joint).Anchor2;
	}
	
	void OnDrawGizmos() {
		if(connectedBody == null) {
            return;
		}
        Gizmos.color = Color.red;
        Gizmos.DrawLine(anchor, connectedAnchor);
	}
}
