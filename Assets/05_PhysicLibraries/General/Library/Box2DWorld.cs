using UnityEngine;
using Box2DX.Dynamics;
using Box2DX.Common;
using Box2DX.Collision;
using System.Collections.Generic;

using Joint = Box2DX.Dynamics.Joint;

public class Box2DWorld : MonoBehaviour, ContactListener {
	
	public float worldAxisAlignedBoundingBoxLowerBoundDefault = -100f;
	public float worldAxisAlignedBoundingBoxUpperBoundDefault = 100f;
	
	public float gravity = 9.8f; // m / s^2
	
	public int velocityIterations = 8;
	public int positionIteration = 1;
	
	static Box2DWorld instance;
	
	World 			_world;
	ContactFilter 	_filter;

	World world { 
		get { 
			if (_world == null)  {
				AABB aabb = new AABB();
#if USING_BOX2DX
				aabb.LowerBound = new Vector2(worldAxisAlignedBoundingBoxLowerBoundDefault, worldAxisAlignedBoundingBoxLowerBoundDefault).ToVec2();
				aabb.UpperBound = new Vector2(worldAxisAlignedBoundingBoxUpperBoundDefault, worldAxisAlignedBoundingBoxUpperBoundDefault).ToVec2();
				world = new World(aabb, new Vector2(0f, -gravity).ToVec2(), true);
#else
				aabb.LowerBound = new Vector2(worldAxisAlignedBoundingBoxLowerBoundDefault, worldAxisAlignedBoundingBoxLowerBoundDefault);
				aabb.UpperBound = new Vector2(worldAxisAlignedBoundingBoxUpperBoundDefault, worldAxisAlignedBoundingBoxUpperBoundDefault);
				_world = new World(aabb, new Vector2(0f, -gravity), true);
				
				 // [CHRISK] There is no default contact filter in this implementation 
				// like many other Box2D libraries so we need to create one
				_filter = new ContactFilter();
				
				_world.SetContactFilter(_filter);
				_world.SetContactListener(this);
#endif 
			}
			return _world;
		}
	}
	
	List<Box2DBody> bodies = new List<Box2DBody>();
	
	public static Box2DWorld Instance() {
		if (instance == null) {
			var g = GameObject.Find("/" + typeof(Box2DWorld).Name);
			if (g == null) { 
				Debug.LogError("failed to locate Box2DWorld within scene");
			}
			instance = g.GetComponent<Box2DWorld>();
		}
		return instance;
	}

	public void CreateBody(Box2DBody box2DBody, BodyDef bodyDef) {
		box2DBody.body = world.CreateBody(bodyDef);
		bodies.Add( box2DBody );
	}
	
	internal Body CreateDefaultGroundBody() { 
		return world.CreateBody(new BodyDef());
	}
	
	public void DestroyBody(Box2DBody box2DBody) {
		if (box2DBody == null) {
			return;
		}
		bodies.Remove(box2DBody);
		world.DestroyBody(box2DBody);
	}
	
	public void DestroyBody(Body body) { 
		world.DestroyBody(body);
	}
	
	public Joint CreateJoint(JointDef jointDef) {
		return world.CreateJoint(jointDef);
	}

	public void DestroyJoint(Joint joint) {
		if (joint == null) {
			return;
		}
		world.DestroyJoint(joint);
	}
	
	public Box2DBody QueryAABB(AABB aabb) {
		Fixture[] fixtures = new Fixture[1];
		if (world.Query(aabb, fixtures, 1) > 0) {
			return (Box2DBody)fixtures[0].UserData;
		}
		return null;
	}
	
	// ContactListener interface
	public void BeginContact(Contact contact) {
	
		Box2DBody box2DBodyA = (Box2DBody)contact.FixtureA.UserData;
		Box2DBody box2DBodyB = (Box2DBody)contact.FixtureB.UserData;
		
		if (box2DBodyA != null) {
			box2DBodyA.SendMessage("OnContactBegin", contact, SendMessageOptions.DontRequireReceiver);
		}
		
		if (box2DBodyB != null) { 
			box2DBodyB.SendMessage("OnContactBegin", contact, SendMessageOptions.DontRequireReceiver);
		}
	}
	
	public void EndContact(Contact contact) {
		
		Box2DBody bodyA = (Box2DBody)contact.FixtureA.UserData;
		Box2DBody bodyB = (Box2DBody)contact.FixtureB.UserData;
		
		if (bodyA != null) {
			bodyA.SendMessage("OnContactEnd", contact, SendMessageOptions.DontRequireReceiver);
		}
		
		if (bodyB != null) { 
			bodyB.SendMessage("OnContactEnd", contact, SendMessageOptions.DontRequireReceiver);
		}
	}
	
	public void PreSolve(Contact contact, Manifold manifold) {
	}
	
	public void PostSolve(Contact contact, ContactImpulse impulse) {
		
		Box2DBody bodyA = (Box2DBody)contact.FixtureA.UserData;
		Box2DBody bodyB = (Box2DBody)contact.FixtureB.UserData;
	
		PostContactPair args;
		args.contact = contact; 
		args.impulse = impulse;
		
		if (bodyA != null) {
			bodyA.SendMessage("OnPostContact", args, SendMessageOptions.DontRequireReceiver);
		}
		
		if (bodyB != null) {
			bodyB.SendMessage("OnPostContact", args, SendMessageOptions.DontRequireReceiver);
		}
	}

	void LateUpdate() { 
		if (world == null) {
			return;
		}
		
		bodies.ForEach(delegate(Box2DBody body) {
			body.PreStepUpdate();
		});
		
		world.Step(Time.deltaTime, velocityIterations, positionIteration);
		
		bodies.ForEach(delegate(Box2DBody body) {
			body.PostStepUpdate();	
		});
	}
}
