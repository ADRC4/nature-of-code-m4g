using UnityEngine;
using System.Collections;
using Box2DX.Dynamics;

public class Box2DRectangleShape : Box2DShapeBase {
	
	public Vector2 center;
	public float halfWidth = 0.5f;
	public float halfHeight = 0.5f;
	public float angle;
	
	PolygonDef _polygonDef; 
	
	PolygonDef polygonDef { 
		get { 
			if (_polygonDef == null) {
				_polygonDef = new PolygonDef();
				_polygonDef.SetAsBox(halfWidth * transform.localScale.x, halfHeight * transform.localScale.y, center, angle);
			}
			return _polygonDef;
		}
	}
	
	public static implicit operator PolygonDef(Box2DRectangleShape box2DPolyShape) {
		return box2DPolyShape.polygonDef;
	}
	
	public override FixtureDef ToFixtureDef() { 
		return polygonDef;
	}
}
