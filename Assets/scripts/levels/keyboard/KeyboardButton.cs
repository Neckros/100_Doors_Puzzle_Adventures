using UnityEngine;
using System.Collections;

public class KeyboardButton : MonoBehaviour {
	public KeyboardEngine keyboard;
	public string value;

	void OnTouchClick() {
		bool isPushed = keyboard.push(value);

		if (isPushed)
			GetComponent<AudioSource>().Play();
	}
}
