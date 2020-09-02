using UnityEngine;
using System.Collections;

public class TweenContinuousRotation : MonoBehaviour {
	public bool rotate;
	public Vector3 eulerAngles;
	
	void FixedUpdate() {
		if (rotate) {
			transform.Rotate(eulerAngles);		
		}
	}
	
	public void play() {
		rotate = true;
	}

	public void stop() {
		rotate = true;
	}
}
