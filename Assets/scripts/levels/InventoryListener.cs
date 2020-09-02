using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryListener : TouchListener {
	public Entity requiredItem;
	public bool removeAfterUsage;
	public bool playInventorySound;

	void OnInventoryClick(Entity entity) {
		if (isTouch && entity.Equals(requiredItem)) {			
			if (removeAfterUsage) 
				entity.remove();

			gameObject.SendMessage("OnInventoryAction", SendMessageOptions.DontRequireReceiver);		
			executeEvents();

			if (playInventorySound) 
				entity.GetComponent<AudioSource>().Play();
		}
	}

	void OnTouchClick() {
	}

	void OnTouchDown() {
	}
}
