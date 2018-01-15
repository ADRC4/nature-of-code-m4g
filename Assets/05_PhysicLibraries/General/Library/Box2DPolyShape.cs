using UnityEngine;
using System.Collections;
using Box2DX.Dynamics;

public class Box2DPolyShape : Box2DShapeBase {
	
	public Vector2[] vertices;
	
	PolygonDef _polygonDef; 
	
	PolygonDef polygonDef { 
		get { 
			if (_polygonDef == null) {
				_polygonDef = new PolygonDef();
				_polygonDef.Vertices = vertices;
				_polygonDef.VertexCount = vertices.Length;
			}
			return _polygonDef;
		}
	}
	
	public static implicit operator PolygonDef(Box2DPolyShape box2DPolyShape) {
		return box2DPolyShape.polygonDef;
	}
	
	public override FixtureDef ToFixtureDef() { 
		return polygonDef;
	}
}
