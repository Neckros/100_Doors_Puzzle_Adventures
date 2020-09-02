using UnityEngine;
using System.Collections;

public class HideKeyboard : MonoBehaviour {
	public KeyboardEngine keyboardEngine;

	void OnTouchClick() {
		keyboardEngine.hide();
	}
}
