using UnityEngine;
using System.Collections;

public class InteractionItem : MonoBehaviour {
	public bool isActive = true;

	void OnTouchUp(Vector2 pos) {
		if (isActive) {
			GameObject hitObject = ExtraManager.Instance.hitThroughObject(pos, gameObject);
			if (hitObject) {
				gameObject.SendMessage("OnTouchListener", gameObject, SendMessageOptions.DontRequireReceiver);
				hitObject.SendMessage("OnItemTouch", gameObject, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}