using UnityEngine;
using System.Collections;

public class SoundClickListener : MonoBehaviour {
	public bool touchable = true;
	public bool onDown;
	public bool onUp;
	public bool onClick = true;

	void OnTouchDown() {
		if (touchable && onDown)
			play();
	}
	
	void OnTouchUp() {
		if (touchable && onUp)
			play();
	}

	void OnTouchClick() {
		if (touchable && onClick)
			play();
	}

	public void play() {
		if (GetComponent<AudioSource>())
			GetComponent<AudioSource>().Play();
		else
			Debug.LogError("AudioSource not found on the GameObject: " + gameObject.name);
	}

	public void touchableEnable() {
		touchable = true;
	}

	public void touchableDisable() {
		touchable = false;
	}
}
