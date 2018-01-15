using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;

public class Box2DTools : MonoBehaviour {
	
	public Material defaultDiffuse;
	
	[MenuItem("Component/Box2D/Create Square")]
	static void CreateSquare() {
		Box2DPrimitives.Create(new Box2DPrimitives.SquarePrimParam());
	}
	
	[MenuItem("Component/Box2D/Create Circle")]
	static void CreateCircle() { 
		Box2DPrimitives.Create(new Box2DPrimitives.CirclePrimParam());
	}
	
	[MenuItem("Component/Box2D/Create Edge")]
	static void CreateEdge() { 
		var g = new GameObject( "Edge", new Type[] { typeof(Box2DEdgeShape), typeof(Box2DBody) } );
		var shape = g.GetComponent<Box2DEdgeShape>();
		shape.vertex1 = new Vector2(-0.5f, 0f);
		shape.vertex2 = new Vector2(0.5f, 0f);
	}
	
	[MenuItem("Component/Box2D/Distance Joint")]
	static void AddDistanceJoint() { 
		var active = Selection.activeGameObject;
		if (active != null) {
			active.AddComponent<Box2DDistanceJoint>();
		}
	}
	
	[MenuItem("Component/Box2D/Revolute Joint")]
	static void AddRevoluteJoint() {
		var active = Selection.activeGameObject;
		if (active != null) {
			active.AddComponent<Box2DRevoluteJoint>();
		}
	}
	
}
