using UnityEngine;
using System.Collections;

public class RotateListener : MonoBehaviour {	
	private Vector2 itemPos;
	private Vector2 dragStart, drag;
	private Quaternion startRotation;

	void OnTouchDown(Vector2 pos) {
		itemPos = Camera.main.WorldToScreenPoint(transform.position);
		startRotation = transform.localRotation;
		dragStart = pos - itemPos;
	}
	
	void OnTouchDrag(Vector2 pos) {
		if (!GetComponent<Collider2D>().enabled)
			return;
		
		drag = pos - itemPos;
		Quaternion rotation = Quaternion.FromToRotation(dragStart, drag);
		rotation *= startRotation;
		transform.localRotation = rotation;
	}
}
