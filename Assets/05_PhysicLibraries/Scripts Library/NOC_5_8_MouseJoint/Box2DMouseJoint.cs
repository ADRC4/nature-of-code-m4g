using UnityEngine;
using System.Collections;
using Box2DX.Dynamics;
using Box2DX.Collision;
using Box2DX.Common;

[RequireComponent(typeof(Box2DBody))]
public class Box2DMouseJoint : Box2DJoint<MouseJoint> {

	public Vector2 worldMousePosition; 
	public float force = 1000f;

	Body defaultGround;
	
	void Start () {

		defaultGround = Box2DWorld.Instance().CreateDefaultGroundBody();
		
		var jointDef = new MouseJointDef();
		
		jointDef.Body1 = defaultGround;
		jointDef.Body2 = GetComponent<Box2DBody>();
		jointDef.Target = worldMousePosition;
		jointDef.FrequencyHz = 30;
		jointDef.DampingRatio = 0.2f;
		jointDef.MaxForce = jointDef.Body2.GetMass() * force;
		
		joint = (MouseJoint)Box2DWorld.Instance().CreateJoint(jointDef);
	}
	
	void Update() { 
		if (joint != null) {
			((MouseJoint)joint).SetTarget( worldMousePosition );
		}
	}
	
	void OnDrawGizmos()  {
	}
	
	void OnDestroy() { 
		SendMessage("DestroyJoint", joint, SendMessageOptions.DontRequireReceiver);
		SendMessage("DestroyBody", defaultGround, SendMessageOptions.DontRequireReceiver);
	}
}
