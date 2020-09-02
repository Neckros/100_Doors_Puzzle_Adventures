using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Entity))]
public class OnInventoryPickUpListener : EventListener {

	void OnInventoryPickUp() {
		executeEvents();
	}
}
