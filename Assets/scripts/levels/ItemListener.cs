using UnityEngine;
using System.Collections;

public class ItemListener : TouchListener {
	public GameObject requirementItem;
	public bool hideItem = false;
	public bool disableCollider = true;
	public bool playItemSound = false;
	public bool playListenerSound = false;
	
	void OnItemTouch(GameObject item) {
		if (!isTouch) {
			return;
		}
		if (item.Equals(requirementItem)) {
			gameObject.SendMessage("OnItemAction", SendMessageOptions.DontRequireReceiver);	

			if (disableCollider) 
				GetComponent<Collider2D>().enabled = false;
			if (hideItem) 
				item.SetActive(false);
			if (playItemSound && item.GetComponent<AudioSource>()) 
				item.GetComponent<AudioSource>().Play();
			if (playListenerSound && GetComponent<AudioSource>()) 
				GetComponent<AudioSource>().Play();
			
			executeEvents();
		}
	}

	void OnTouchClick() {
	}
	
	void OnTouchDown() {
	}

}
