using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class AccelerometerListener : MonoBehaviour {
	public bool isX = true, isY = true;
	public float power = 1;
	private Vector2 force = new Vector3();
	private bool isDesktop;

	void Awake() {
		isDesktop = ExtraManager.isDesktop;
	}

	void Update() {
		if (isDesktop) {
			force = Vector2.zero;
			
			if (Input.GetKey(KeyCode.LeftArrow)) {
				force.x = -power;
			}
			if (Input.GetKey(KeyCode.RightArrow)) {
				force.x = +power;
			}
			if (Input.GetKey(KeyCode.UpArrow)) {
				force.y = +power;
			}
			if (Input.GetKey(KeyCode.DownArrow)) {
				force.y = -power;
			}
		} else {
			force = Input.acceleration * power;
		}

		if (!isX)
			force.x = 0;
		if (!isY)
			force.y = 0;

		GetComponent<Rigidbody2D>().AddForce(force);
	}
}
