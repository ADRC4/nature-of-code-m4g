using UnityEngine;
using System.Collections;
using Box2DX.Common;
using Box2DX.Dynamics;
using Box2DX.Collision;

public class Box2DMousePicker : MonoBehaviour {
	
	public float force = 1000f;
	
	Box2DMouseJoint mouseJoint;
	
	Plane plane = new Plane(Vector3.forward, Vector3.zero);
	
	void Update () {
		
		var ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
		
		float rayIntersect;
		if (!plane.Raycast(ray, out rayIntersect)) {
			return;
		}
		
		var pointOfInteresect = ray.GetPoint(rayIntersect);
		
		if (Input.GetMouseButtonDown(0)) { 
			
			AABB aabb;
			Vector2 nudge = new Vector2(0.001f, 0.001f);
			
			aabb.LowerBound = (Vector2)pointOfInteresect - nudge;
			aabb.UpperBound = (Vector2)pointOfInteresect + nudge;
			
			Box2DBody body = Box2DWorld.Instance().QueryAABB(aabb);
			
			if (body != null)  {
				mouseJoint = body.gameObject.AddComponent<Box2DMouseJoint>();
				mouseJoint.worldMousePosition = pointOfInteresect;
				mouseJoint.force = force;
			}
		}
		
		if (Input.GetMouseButton(0)) { 
			if (mouseJoint != null) {
          		mouseJoint.worldMousePosition = pointOfInteresect;
        	}
		}
        
        if (Input.GetMouseButtonUp(0)) {
            if (mouseJoint != null) {
                Destroy(mouseJoint);
                mouseJoint = null;
            }
        }
	}
}