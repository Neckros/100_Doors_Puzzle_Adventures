using UnityEngine;
using System.Collections;

public class CollisionListener : EventListener {
	public enum Type {
		Collision,
		Trigger
	}

	public enum Method {
		Enter,
		Exit,
		Stay
	}

	public Type type;
	public Method method;
	public GameObject targetObject;

	void OnAction(GameObject collisionObject) {
		if (!targetObject || collisionObject == targetObject) {
			executeEvents();				
		}
	}

	// Listeners...

	void OnCollisionEnter2D(Collision2D collision) {
		if (type == Type.Collision) 
			if (method == Method.Enter) 
				OnAction(collision.gameObject);
	}
	
	void OnCollisionExit2D(Collision2D collision) {		
		if (type == Type.Collision) 
			if (method == Method.Exit) 
				OnAction(collision.gameObject);
	}
	
	void OnCollisionStay2D(Collision2D collision) {
		if (type == Type.Collision) 
			if (method == Method.Stay) 
				OnAction(collision.gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		if (type == Type.Trigger) 
			if (method == Method.Enter) 
				OnAction(collider.gameObject);
	}
	
	void OnTriggerExit2D(Collider2D collider) {
		if (type == Type.Trigger) 
			if (method == Method.Exit) 
				OnAction(collider.gameObject);
	}
	
	void OnTriggerStay2D(Collider2D collider) {
		if (type == Type.Trigger) 
			if (method == Method.Stay) 
				OnAction(collider.gameObject);
	}
}
