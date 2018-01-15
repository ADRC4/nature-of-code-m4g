using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Box2DPrimitives {
	
	const int DEFAULT_CIRCLE_SEGMENTS = 16;
	
	public enum PrimType 
	{
		Unknown,
		Triangle,
		Square,
		Circle
	}
	
	public class PrimParam 
	{
		public PrimParam() 
		{
			type = PrimType.Unknown;
		}
		
		internal PrimType type;
	}
	
	public class SquarePrimParam : PrimParam 
	{
		const float DEFAULT_SIDE = 0.5f;
		
		public SquarePrimParam() 
		{
			type = PrimType.Square;
			center = Vector2.zero;
			halfWidth = DEFAULT_SIDE;
			halfHeight = DEFAULT_SIDE;
			angle = 0f;
		}	
		
		public Vector2 center;
		public float halfWidth;
		public float halfHeight;
		public float angle;
	}
	
	public class CirclePrimParam : PrimParam
	{ 
		const float DEFAULT_RADIUS = 0.5f;

		public CirclePrimParam() 
		{
			type = PrimType.Circle;
			center = Vector2.zero;
			radius = DEFAULT_RADIUS;
		}
		
		public Vector2 center;
		public float radius;
	}
	
	static public GameObject Create(PrimParam param) {
	
		switch(param.type) 
		{ 
		case PrimType.Triangle:
			return CreateTriangle();
		case PrimType.Square:
			return CreateSquare((SquarePrimParam)param);
		case PrimType.Circle:
			return CreateCircle((CirclePrimParam)param);
		}
		
		return null;
	}
	
	static GameObject CreateTriangle() { 
		return null;
	}
	
	static GameObject CreateSquare(SquarePrimParam param) { 
				
		var g = new GameObject( "Square", new Type[] { typeof(MeshRenderer), typeof(MeshFilter), typeof(Box2DBody), typeof(Box2DRectangleShape) } );
		g.GetComponent<Renderer>().castShadows = false;
		g.GetComponent<Renderer>().receiveShadows = false;
		g.GetComponent<Renderer>().material.color = Color.grey;
		
		var shape = g.GetComponent<Box2DRectangleShape>();
		
		shape.center = param.center;
		shape.halfWidth = param.halfWidth;
		shape.halfHeight = param.halfHeight;
		shape.angle = param.angle;
			
		Mesh mesh = new Mesh();
		mesh.vertices = new Vector3[] { new Vector3(-shape.halfWidth, shape.halfHeight, 0), new Vector3(shape.halfWidth, shape.halfHeight, 0), new Vector3(shape.halfWidth, -shape.halfHeight, 0), new Vector3(-shape.halfWidth, -shape.halfHeight, 0) };
		mesh.normals = new Vector3[] { new Vector3(0, 0, -1), new Vector3(0, 0, -1), new Vector3(0, 0, -1), new Vector3(0, 0, -1) };
		mesh.uv = new Vector2[] { new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0), new Vector2(0, 0) };
        mesh.triangles = new int[] { 0, 1, 2, 2, 3, 0 };
		var mf = g.GetComponent<MeshFilter>();
		mf.mesh = mesh;
		
		return g;
	}
	

	static GameObject CreateCircle(CirclePrimParam param) { 
		
		var g = new GameObject( "Circle", new Type[] { typeof(MeshRenderer), typeof(MeshFilter), typeof(Box2DBody), typeof(Box2DCircleShape) } );
		g.GetComponent<Renderer>().castShadows = false;
		g.GetComponent<Renderer>().receiveShadows = false;
		g.GetComponent<Renderer>().material.color = Color.grey;
		
		var shape = g.GetComponent<Box2DCircleShape>();
		shape.center = param.center;
		shape.radius = param.radius;
		
		float deltaAngle = Mathf.PI * 2f / DEFAULT_CIRCLE_SEGMENTS; 
		
		List<Vector3> circlePoints = new List<Vector3>();
		List<Vector3> normals = new List<Vector3>();
		List<Vector2> uvs = new List<Vector2>();
		List<int> triangles = new List<int>();
		
		int i;
		
		for (i = 0; i < DEFAULT_CIRCLE_SEGMENTS; ++i) {
			float x = param.radius * Mathf.Cos(i * deltaAngle);
			float y = param.radius * Mathf.Sin(i * deltaAngle);
			circlePoints.Add( new Vector3(x, y, 0f) );
			normals.Add( new Vector3(0, 0, -1) );
			uvs.Add( new Vector2(0.5f + x, 0.5f + y) );
			triangles.Add((i + 1) % DEFAULT_CIRCLE_SEGMENTS);
			triangles.Add(i);
			triangles.Add(DEFAULT_CIRCLE_SEGMENTS);
		}
	
		circlePoints.Add( Vector3.zero ); // center
		normals.Add( new Vector3(0, 0, -1) );
		uvs.Add( new Vector2( 0.5f, 0.5f) );
	
		Mesh mesh = new Mesh();
		mesh.vertices = circlePoints.ToArray();
		mesh.normals = normals.ToArray();
		mesh.triangles = triangles.ToArray();
		mesh.uv = uvs.ToArray();
		
		var mf = g.GetComponent<MeshFilter>();
		mf.mesh = mesh;
	
		return g;
	}
}
