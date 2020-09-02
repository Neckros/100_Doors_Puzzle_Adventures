using UnityEngine;
using System.Collections;

public class WipeListener : EventListener {
	public bool forcedDrag;
	public Parameter targetParameter;
	public float targetValue;
	public float modifier;
	public float finishValue;
	private bool isComplete;

	public enum Parameter {
		Color_a,
		Color_Material_a
	}
	
	void OnTouchDrag() {
		if (isComplete || forcedDrag)
			return;
		
		act();
	}

	void OnTouchDragForced() {
		if (isComplete || !forcedDrag)
			return;
		
		act();
	}

	void act() {
		if (!checkComplete()) {
			modify();
		} else {
			complete();
		}
	}

	bool checkComplete() {
		if (getValue() == targetValue) {
			return true;
		}
		return false;
	}

	void modify() {
		float value = getValue();
		float nextValue = value + modifier;
		if (value < targetValue) 
			nextValue = Mathf.Min(nextValue, targetValue);
		else if (value > targetValue)
			nextValue = Mathf.Max(nextValue, targetValue);
		else
			nextValue = value;

		setValue(nextValue);

		print(nextValue);
	}
	
	float getValue() {
		if (targetParameter == Parameter.Color_a) {
			return ((SpriteRenderer)GetComponent<Renderer>()).color.a;
		} else if (targetParameter == Parameter.Color_Material_a) {
			return GetComponent<Renderer>().material.color.a;
		}
		return 0;
	}

	void setValue(float value) {
		if (targetParameter == Parameter.Color_a) {
			Color color = ((SpriteRenderer)GetComponent<Renderer>()).color;
			color.a = value;
			((SpriteRenderer)GetComponent<Renderer>()).color = color;
		} else if (targetParameter == Parameter.Color_Material_a) {
			Color color = GetComponent<Renderer>().material.color;
			color.a = value;
			GetComponent<Renderer>().material.color = color;
		}
	}

	void complete() {
		isComplete = true;

		setValue(finishValue);

		executeEvents();
	}
}
