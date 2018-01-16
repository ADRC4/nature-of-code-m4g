using UnityEngine;
using System.Collections;
using Box2DX.Dynamics;

[RequireComponent(typeof(Box2DBody))]
public class Box2DGearJoint : Box2DJoint<GearJoint> {
	
	public Box2DBody connectedBody;
	public RevoluteJoint joint1;
	public RevoluteJoint joint2;
	
	void Start () {
		//if (connectedBody == null) {
			var jointDef = new GearJointDef();
			jointDef.Body1 = GetComponent<Box2DBody>();
			jointDef.Body2 = connectedBody;
			jointDef.Joint1 = joint1;
			jointDef.Joint2 = joint2;
			
			
			// [CHRISK] TODO
		//}
		
		#if USING_BOX2DX
		#else
		//	jointDef.Initialize(connectedBody, GetComponent<Box2DBody>(), anchor);
		#endif
		
		var world = Box2DWorld.Instance();
		joint = (GearJoint)world.CreateJoint(jointDef);
		
	}
	
	
	

}
