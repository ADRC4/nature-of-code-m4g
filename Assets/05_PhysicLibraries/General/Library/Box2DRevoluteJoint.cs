using UnityEngine;
using System.Collections;
using Box2DX.Dynamics;

[RequireComponent(typeof(Box2DBody))]
public class Box2DRevoluteJoint : Box2DJoint<RevoluteJoint> {
	
	public Box2DBody connectedBody;
	public Vector2 anchor;
	
	public float motorSpeed;
	public float maxMotorTorque;
	public bool enableMotor = false;
	public bool collideConnected = false;
	//public bool anchorOneSelf;
	//public bool anchorOneConnectedBody;
	//public bool chainConnector;
	
	public enum ConnectionPosition{
		Self,
		ConnectedBody,
		Chain,
		CustomAnchorPosition
		
	}
	
	public ConnectionPosition positionConnected = Box2DRevoluteJoint.ConnectionPosition.CustomAnchorPosition;
	
	void Awake(){
		switch (positionConnected){
			case ConnectionPosition.Self:
			anchor.x = transform.position.x;	
			anchor.y = transform.position.y;
			break;
			case ConnectionPosition.CustomAnchorPosition:
			anchor.x = anchor.x;	
			anchor.y = anchor.y;
			break;
			case ConnectionPosition.ConnectedBody:
			anchor.x = connectedBody.transform.position.x;	
			anchor.y = connectedBody.transform.position.y;
			break;
			case ConnectionPosition.Chain:
			//float distance = Vector2.Distance(new Vector2(transform.position.x,transform.position.y),new Vector2(connectedBody.transform.position.x,connectedBody.transform.position.y));
			//float angle = Vector2.Angle(new Vector2(transform.position.x,transform.position.y),new Vector2(connectedBody.transform.position.x,connectedBody.transform.position.y));
			Vector3 delta = connectedBody.transform.position - transform.position;
			anchor = transform.position + (delta*0.5f); 
	
			//anchor.x = finalPos.x;
			//anchor.y = finalPos.y;
			break;
			
		}
	}
	
	void Start () {
		if (connectedBody == null) { 
			return;
		}
		var jointDef = new RevoluteJointDef();
#if USING_BOX2DX
		jointDef.Initialize(connectedBody, GetComponent<Box2DBody>(), anchor.ToVec2());
#else
		jointDef.Initialize(connectedBody, GetComponent<Box2DBody>(), anchor);
#endif
		jointDef.MotorSpeed = motorSpeed;
		jointDef.MaxMotorTorque = maxMotorTorque;
		jointDef.EnableMotor = enableMotor;
		jointDef.CollideConnected = collideConnected;
		
		joint = (RevoluteJoint)Box2DWorld.Instance().CreateJoint(jointDef);
	}
	
	void Update() { 
		joint.MotorSpeed = motorSpeed;
	}
	
	
	void OnDrawGizmos() { 
        if (connectedBody != null) {
			Gizmos.DrawLine(transform.position,connectedBody.transform.position);
        }
    }
}
