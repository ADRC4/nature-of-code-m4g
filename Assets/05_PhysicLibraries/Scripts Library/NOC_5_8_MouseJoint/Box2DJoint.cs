using UnityEngine;
using System.Collections;

public class Box2DJoint<T> : MonoBehaviour {

	protected T joint;
	
	void OnDestroy() { 
		SendMessage("DestroyJoint", joint, SendMessageOptions.DontRequireReceiver);
	}
}
