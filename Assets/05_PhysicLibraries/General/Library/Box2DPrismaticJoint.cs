using UnityEngine;
using System.Collections;
using Box2DX.Dynamics;

[RequireComponent(typeof(Box2DBody))]
public class Box2DPrismaticJoint : Box2DJoint<PrismaticJoint> {
	
	public Box2DBody connectedBody;
	public Vector2 anchor;
	public Vector2 axis;
	public float maxMotorForce;
	public bool enableMotor = false;
	
	public bool AnchorOneSelf;
	public bool AnchorOneConnectedBody;
	
	void OnDrawGizmos() { 
        if (connectedBody != null) {
			Gizmos.DrawLine(transform.position,connectedBody.transform.position);
        }
    }
	
	void Awake(){
		if(AnchorOneSelf){
			anchor.x = transform.position.x;	
			anchor.y = transform.position.y;
		}
		if(AnchorOneConnectedBody){
			anchor.x = connectedBody.transform.position.x;	
			anchor.y = connectedBody.transform.position.y;
		}
	}

	void Start () {
		if (connectedBody == null) { 
			return;
		}
		var jointDef = new PrismaticJointDef();
#if USING_BOX2DX
		jointDef.Initialize(GetComponent<Box2DBody>(), connectedBody, anchor.ToVec2(), axis.ToVec2());
#else
		jointDef.Initialize(GetComponent<Box2DBody>(), connectedBody, anchor, axis);
#endif
		jointDef.MaxMotorForce = maxMotorForce;
		jointDef.EnableMotor = enableMotor;
		
		joint = (PrismaticJoint)Box2DWorld.Instance().CreateJoint(jointDef);
	}
}
