using UnityEngine;
using System.Collections;

public class ObjectEvents : MonoBehaviour {
	
	public enum Object {
		GameObject,
		Sprite,
		Collider2D,
		Rigidbody2D
	}

	public enum Action {
		Off,
		On,
		Swith
	}
	public Object targetObject;
	public Action targetAction;

	public void runAction() {
		if (targetAction == Action.Off) {
			turnOff();
		} else if (targetAction == Action.On) {
			turnOn();
		} else if (targetAction == Action.Swith) {
			switchState();
		}		
	}
	
	//
	public bool isEnabled() {
		if (targetObject == Object.GameObject) {
			return gameObject.activeSelf;
		} else if (targetObject == Object.Sprite) {
			return gameObject.GetComponent<SpriteRenderer>().enabled;			
		} else if (targetObject == Object.Collider2D) {
			return GetComponent<Collider2D>().enabled;			
		} else if (targetObject == Object.Rigidbody2D) {
			return !GetComponent<Rigidbody2D>().isKinematic;			
		}
		Debug.LogException(new System.Exception("ObjectActivity: Target - not handled!"));
		return false;
	}
	
	public void setState(bool isEnabled) {		
		setState(targetObject, isEnabled);
	}

	public void setState(Object component, bool isEnabled) {		
		if (component == Object.GameObject) {
			gameObject.SetActive(isEnabled);
		} else if (component == Object.Sprite) {
			gameObject.GetComponent<SpriteRenderer>().enabled = isEnabled;			
		} else if (component == Object.Collider2D) {
			GetComponent<Collider2D>().enabled = isEnabled;			
		} else if (component == Object.Rigidbody2D) {
			GetComponent<Rigidbody2D>().isKinematic = !isEnabled;			
		}
	}
	
	public void turnOn() {
		setState(true);
	}
	
	public void turnOff() {
		setState(false);
	}
	
	public void switchState() {
		setState(!isEnabled());
	}

	public void playSound() {		
		if (GetComponent<AudioSource>())
			GetComponent<AudioSource>().Play();
		else
			Debug.LogError("AudioSource not found on the GameObject: " + gameObject.name);
	}
	
	public void objectOn() {
		setState(Object.GameObject, true);
	}

	public void objectOff() {
		setState(Object.GameObject, false);
	}

	public void spriteOn() {
		setState(Object.Sprite, true);
	}

	public void spriteOff() {
		setState(Object.Sprite, false);
	}

	public void colliderOn() {
		setState(Object.Collider2D, true);
	}

	public void colliderOff() {
		setState(Object.Collider2D, false);
	}

	public void rigidbodyOn() {
		setState(Object.Rigidbody2D, true);
	}

	public void rigidbodyOff() {
		setState(Object.Rigidbody2D, false);
	}
}
