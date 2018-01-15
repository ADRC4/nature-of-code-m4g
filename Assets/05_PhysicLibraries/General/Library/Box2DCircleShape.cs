using UnityEngine;
using Box2DX.Dynamics;

using Color = UnityEngine.Color;

public class Box2DCircleShape : Box2DShapeBase {
	
	public Vector2 center;
	public float radius = 0.5f;
	
	CircleDef _circleDef;
	
	CircleDef circleDef { 
		get { 
			if (_circleDef == null) {
				_circleDef = new CircleDef();
				_circleDef.LocalPosition = center;
				_circleDef.Radius = radius * transform.localScale.x;
			}
			return _circleDef;
		}
	}
	
	public static implicit operator CircleDef(Box2DCircleShape box2DCircleShape) {
		return box2DCircleShape.circleDef;
	}
	
	public override FixtureDef ToFixtureDef() {
		return circleDef;
	}
	
	void OnDrawGizmos() {
		//Gizmos.color = Color.green;
		//Gizmos.DrawSphere(transform.TransformPoint(center), radius * transform.localScale.x);
	}
}
