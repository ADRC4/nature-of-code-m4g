using UnityEngine;
using Box2DX.Dynamics;

[RequireComponent(typeof(Box2DBody))]
public class Box2DPulleyJoint : Box2DJoint<PulleyJoint> {
	
	public Box2DBody startBody;
	public Box2DBody connectedBody;
	public Box2DBody groundAnchorBody1;
	public Box2DBody groundAnchorBody2;
	public Vector2 groundAnchor1;
	public Vector2 groundAnchor2;
	public Vector2 anchor1;
	public Vector2 anchor2;
	public float ratio;
	public bool selfAnchor = false;
	
	void OnDrawGizmos() { 
        if (connectedBody != null) {
		//	Gizmos.DrawLine(transform.position,connectedBody.transform.position);
        }
		if(selfAnchor){
			Gizmos.DrawLine(groundAnchorBody1.transform.position,transform.position);
		}else{
			Gizmos.DrawLine(groundAnchorBody1.transform.position,startBody.transform.position);
		}
		
		Gizmos.DrawLine(groundAnchorBody1.transform.position,groundAnchorBody2.transform.position);
		Gizmos.DrawLine(connectedBody.transform.position,groundAnchorBody2.transform.position);
    }
	
	void Awake(){
		if(selfAnchor){
			anchor1.x = startBody.transform.position.x;	
			anchor1.y = startBody.transform.position.y;
		}else{
			anchor1.x = startBody.transform.position.x;	
			anchor1.y = startBody.transform.position.y;
				
		}
		
		anchor2.x = connectedBody.transform.position.x;	
		anchor2.y = connectedBody.transform.position.y;
		
		groundAnchor1.x = groundAnchorBody1.transform.position.x;	
		groundAnchor1.y = groundAnchorBody1.transform.position.y;	
		
		groundAnchor2.x = groundAnchorBody2.transform.position.x;	
		groundAnchor2.y = groundAnchorBody2.transform.position.y;
	}
	
	
	void Start () {
		var jointDef = new PulleyJointDef();
#if USING_BOX2DX
		jointDef.Initialize(GetComponent<Box2DBody>(), connectedBody,
			groundAnchor1.ToVec2(), groundAnchor2.ToVec2(), anchor1.ToVec2(), anchor2.ToVec2(), ratio);
			
#else
		//jointDef.Length1 = 10f;
		
		jointDef.Initialize(GetComponent<Box2DBody>(), connectedBody, groundAnchor1, groundAnchor2, anchor1, anchor2, ratio);
		
		jointDef.MaxLength1 = 10f;
		jointDef.MaxLength2 = 10f;
#endif 
		joint = (PulleyJoint)Box2DWorld.Instance().CreateJoint(jointDef);
	}
}
