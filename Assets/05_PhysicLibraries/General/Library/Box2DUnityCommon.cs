using UnityEngine;

#if USING_BOX2DX
using Box2DX.Common;
#endif 

public static class TransformExtension
{
	public static float AngleAroundZ(this Transform transform)
	{
		return transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
	}
}

#if USING_BOX2DX
public static class Vec2Extension 
{
	public static Vector2 ToVector2(this Vec2 vector) 
	{
		return new Vector2(vector.X, vector.Y);
	}
}

public static class Vector2Extension
{
	public static Vec2 ToVec2(this Vector2 vector)
	{
		return new Vec2(vector.x, vector.y);
	}
}

public static class Vector3Extension
{
	public static Vec2 ToVec2(this Vector3 vector)
	{
		return new Vec2(vector.x, vector.y);
	}
}
#endif
