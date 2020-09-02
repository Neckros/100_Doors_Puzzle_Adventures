using UnityEngine;
using System.Collections;

public class ShakeListener : EventListener {
	public float requiredShake = 2;
	public float lowPassKernelWidthInSeconds = 1;
	public bool removeAfterShake = false;
	// The greater the value of LowPassKernelWidthInSeconds, the slower the filtered value will converge towards current input sample (and vice versa). You should be able to use LowPassFilter() function instead of avgSamples(). 
		
	private float accelerometerUpdateInterval = 1f / 60f;
	private float LowPassFilterFactor;
	private Vector3 lowPassValue = Vector3.zero; // should be initialized with 1st sample	
	private Vector3  acc;
	private Vector3 deltaAcc;

	void Awake() {
		LowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
	}

	///////////////////////	
	Vector3 lowPassFilter(Vector3 newSample) {		
		lowPassValue = Vector3.Lerp(lowPassValue, newSample, LowPassFilterFactor);		
		return lowPassValue;		
	}	
	
	///////////////////////	
	void FixedUpdate() {
		if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.T)) {
			shake();
		}

		acc = Input.acceleration;		
		deltaAcc = acc - lowPassFilter(acc);	
		if (Mathf.Abs(deltaAcc.x) >= requiredShake) {	
			shake();
		}
		
		if (Mathf.Abs(deltaAcc.y) >= requiredShake) {			
			shake();
		}
		
		if (Mathf.Abs(deltaAcc.z) >= requiredShake) {			
			shake();
		}       		
	}

	void shake() {
		print("Shake");
		gameObject.SendMessage("OnShake", SendMessageOptions.DontRequireReceiver);		
		executeEvents();
		if (removeAfterShake) {
			Destroy(this);
		}
	}

}
