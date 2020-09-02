using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchListener : EventListener {
	public bool isTouch = true;
	public TouchMethod trigger = TouchMethod.OnTouchClick;

	void OnTouchClick() {
		if (isTouch && trigger == TouchMethod.OnTouchClick) {
			executeEvents();
		}
	}
	
	void OnTouchDown() {
		if (isTouch && trigger == TouchMethod.OnTouchDown) {
			executeEvents();
		}
	}

	void OnTouchUp() {
		if (isTouch && trigger == TouchMethod.OnTouchUp) {
			executeEvents();
		}
	}
	
	public void touchableEnable() {
		isTouch = true;
	}

	public void touchableDisable() {
		isTouch = false;		
	}

}
