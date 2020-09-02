using UnityEngine;
using System.Collections;

public class ShowKeyboard : MonoBehaviour {
	public KeyboardEngine keyboardEngine;

	void OnTouchClick() {
		keyboardEngine.show();
	}
}
