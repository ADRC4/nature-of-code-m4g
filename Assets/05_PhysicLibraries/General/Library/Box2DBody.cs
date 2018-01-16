using UnityEngine;
using System;
using System.Collections;
using Box2DX.Dynamics;
using Box2DX.Collision;
using Box2DX.Common;

using Joint = Box2DX.Dynamics.Joint;

public class Box2DBody : MonoBehaviour {

	public float density = 0.0f;
	public float friction = 0.3f;
	public float restitution = 0.2f;
	public float drag = 0f;
	public float angularDamping = 0f;
	
	public bool setMassFromShapes = false;
	
	//public delegate void CollisionEventHandler(CollisionInfo info);
	public delegate void CollisionBeginEventHandler(Contact contact);
	public delegate void CollisionEndEventHandler(Contact contact);
	public delegate void PostCollideEventHandler(Contact contact, ContactImpulse impulse);
	
	//public event CollisionEventHandler OnCollision;
	public event CollisionBeginEventHandler OnCollisionBegin;
	public event CollisionEndEventHandler OnCollisionEnd;
	public event PostCollideEventHandler OnPostCollide;
	
	Box2DWorld _world;
	Body _body;
	
	public Body body { 
		get {
			if (_body == null) {
				CreateBody();
			}
			return _body;
		}
		set { 
			_body = value; 
		} 
	}
	
	public static implicit operator Body(Box2DBody box2DBody)
    {
		return box2DBody.body;
	}
	
	void Start()
    { 
		_world = Box2DWorld.Instance();
	}
	
	void CreateFixture<T>(T shape) where T : Box2DShapeBase
	{
		var fixtureDef = shape.ToFixtureDef();
		fixtureDef.Density = density;
		fixtureDef.Friction = friction;
		fixtureDef.Restitution = restitution;
		
		var filter = shape.GetComponent<Box2DFilter>();
		if (filter != null) {
			var filterData = (FilterData)filter;
			fixtureDef.Filter.CategoryBits = filterData.CategoryBits;
			fixtureDef.Filter.MaskBits = filterData.MaskBits;
			fixtureDef.Filter.GroupIndex = filterData.GroupIndex;
		}
		
		var fixture = body.CreateFixture(fixtureDef);
		if (fixture != null) { 
			fixture.UserData = this;
		}
	}
	
	void CreateBody()
    {
		
		BodyDef bodyDef = new BodyDef();
		bodyDef.Position = transform.position;
		bodyDef.Angle = transform.AngleAroundZ();
		bodyDef.LinearDamping = drag;
		bodyDef.AngularDamping = angularDamping;
		Box2DWorld box2Dworld = Box2DWorld.Instance();
		box2Dworld.CreateBody(this, bodyDef);
	
		var rectShapes = GetComponents<Box2DRectangleShape>();
		if (rectShapes != null) { 
			Array.ForEach(rectShapes, CreateFixture<Box2DRectangleShape>); 
		}
		
		var polyShapes = GetComponents<Box2DPolyShape>();
		if (polyShapes != null) {
			Array.ForEach(polyShapes, CreateFixture<Box2DPolyShape>);
		}
		
		var edgeShapes = GetComponents<Box2DEdgeShape>();
		if (edgeShapes != null) {
			Array.ForEach(edgeShapes, CreateFixture<Box2DEdgeShape>);
		}
		
		var circleShapes = GetComponents<Box2DCircleShape>();
		if (circleShapes != null) { 
			Array.ForEach(circleShapes, CreateFixture<Box2DCircleShape>);
		}
		
		if (setMassFromShapes) {
			body.SetMassFromShapes();
		}	
	}
	
	void Update() {		
		body.SetTransform(transform.position, transform.rotation);
	}
	
	internal void PreStepUpdate() {
		//body.SetTransform(transform.position, transform.rotation);
	}
	
	internal void PostStepUpdate() {
		transform.position = body.GetPosition();
		transform.rotation = QuaternionExtension.FromAngle2D(body.GetAngle());
	}
	
	// Message responders
	void DestroyJoint(Joint joint) {
		if (_world != null && joint != null) {
			_world.DestroyJoint(joint);
		}
	}
	
	void DestroyWorld(Body body) {
		if (_world != null && body != null) { 
			_world.DestroyBody(body);
		}
	}
	
	void OnDestroy() {
		if (_world != null) {
			_world.DestroyBody(this);
		}
	}
	
	public void ApplyForce(Vector2 force, Vector2 point) { 
		body.ApplyForce(force, point);
	}
	
	public void ApplyTorque(float torque) { 
		body.ApplyTorque(torque);
	}
	
	public void ApplyLinearImpulse(Vector2 impulse, Vector2 point) {
		Debug.LogWarning("TODO: ApplyLinearImpluse is not yet implemented");
	}
	
	public void ApplyAngularImpulse(float impulse) { 
		Debug.LogWarning("TODO: ApplyAngularImplulse is not yet implemented");
	}

	void OnContactBegin(Contact contact) {
		if (OnCollisionBegin != null) 
			OnCollisionBegin(contact);
	}
	
	void OnContactEnd(Contact contact) { 
		if (OnCollisionEnd != null)
			OnCollisionEnd(contact);
	}
	
	void OnPostContact(PostContactPair args) { 
		if (OnPostCollide != null)
			OnPostCollide(args.contact, args.impulse);
	}
}
