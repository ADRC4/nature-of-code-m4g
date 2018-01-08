
	using Box2DX.Dynamics;
	using Box2DX.Collision;
	using Box2DX.Common;
	using Box2DX.Dynamics;
	public class Box2DSomething {
		//private var world:b2World=new b2World(new b2Vec2(0,10),true);
		//private var worldScale:Number=30;
		//private var theCog:b2Body;
	/*
		public void Main() {
			debugDraw();
			addCog(Math.random()*340+150,Math.random()*180+150,Math.random()*100+50,Math.random()*30+5,Math.random()*20+5,Math.floor(Math.random()*15)+6,Math.random()+1);
			addEventListener(Event.ENTER_FRAME,update);
			stage.addEventListener(MouseEvent.CLICK,createCog);
		}
		
		private void addCog(int pX ,int pY,int r ,int cogWidth,int cogHeight,int nCogs,int motorSpeed) {
			var b2FixtureDef = new b2FixtureDef();
			fixtureDef.restitution=0;
			fixtureDef.density=1;
			var b2CircleShape=new b2CircleShape(r/worldScale);
			fixtureDef.shape=circleShape;
			var b2BodyDef=new b2BodyDef();
			bodyDef.userData=new Sprite();
			bodyDef.position.Set(pX/worldScale,pY/worldScale);
			bodyDef.type=b2Body.b2_dynamicBody;
			theCog=world.CreateBody(bodyDef);
			theCog.CreateFixture(fixtureDef);
			var b2PolygonShape = new b2PolygonShape();
			for (int i =0; i<nCogs; i++) {
				int angle = 2*Math.PI/nCogs*i;
				 polygonShape.SetAsOrientedBox(cogWidth/worldScale/2,cogHeight/worldScale/2,new Vector2(r*Math.cos(angle)/worldScale,r*Math.sin(angle)/worldScale),angle);
				fixtureDef.shape=polygonShape;
				theCog.CreateFixture(fixtureDef);
			}
			var containerJoint=new b2RevoluteJointDef();
			Vector2 anchorA=new Vector2(0,0);
			Vector2 anchorB=new Vector2(pX/worldScale,pY/worldScale);
			containerJoint.localAnchorA.Set(anchorA.x,anchorA.y);
			containerJoint.localAnchorB.Set(anchorB.x,anchorB.y);
			containerJoint.bodyA=theCog;
			containerJoint.bodyB=world.GetGroundBody();
			containerJoint.enableMotor=true;
			containerJoint.maxMotorTorque=50000;
			containerJoint.motorSpeed=motorSpeed;
			world.CreateJoint(containerJoint);
		}
		private void debugDraw(){
			var debugDraw = new b2DebugDraw();
			var debugSprite = new Sprite();
			addChild(debugSprite);
			debugDraw.SetSprite(debugSprite);
			debugDraw.SetDrawScale(worldScale);
			debugDraw.SetFlags(b2DebugDraw.e_shapeBit|b2DebugDraw.e_jointBit);
			debugDraw.SetFillAlpha(0.5);
			world.SetDebugDraw(debugDraw);
		}
	 */
	}
