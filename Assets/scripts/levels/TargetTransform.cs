using UnityEngine;
using System.Collections;

public class TargetTransform : MonoBehaviour {
	public bool isPosition = true;
	public Vector3 position;
	public bool isRotation = false;
	public Vector3 rotation;
	public bool isScale = false;
	public Vector3 scale;
	public Transform parentTransform;

	public void execute() {
		if (parentTransform) 
			gameObject.transform.parent = parentTransform;

		if (isPosition)
			gameObject.transform.localPosition = position;
		if (isRotation)
			gameObject.transform.localRotation = Quaternion.Euler(rotation);
		if (isScale)
			gameObject.transform.localScale = scale;
	}
}
