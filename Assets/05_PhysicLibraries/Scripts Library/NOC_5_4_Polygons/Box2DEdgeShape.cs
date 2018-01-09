using UnityEngine;
using Box2DX.Common;
using Box2DX.Dynamics;

using Color = UnityEngine.Color;

public class Box2DEdgeShape : Box2DShapeBase {
	
	public Vector2 vertex1 = new Vector2(-1f, 0f);
	public Vector2 vertex2 = new Vector2(1f, 0f);
	
	EdgeDef _edgeDef;
	
	EdgeDef edgeDef { 
		get { 
			if (_edgeDef == null) {
				_edgeDef = new EdgeDef();
#if USING_BOX2DX
				_edgeDef.Vertex1 = vertex1.ToVec2();
				_edgeDef.Vertex2 = vertex2.ToVec2();
#else
				_edgeDef.Vertex1 = new Vector2( vertex1.x * transform.localScale.x, vertex1.y * transform.localScale.y );
				_edgeDef.Vertex2 = new Vector2( vertex2.x * transform.localScale.x, vertex2.y * transform.localScale.y );
#endif
			}
			return _edgeDef;
		}
	}
	
	public override FixtureDef ToFixtureDef() { 
		return edgeDef;
	}
	
	void OnDrawGizmos() {
		Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.TransformPoint(vertex1), transform.TransformPoint(vertex2));
	}
}
