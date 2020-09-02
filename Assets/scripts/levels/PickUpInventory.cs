using UnityEngine;
using System.Collections;

public class PickUpInventory : MonoBehaviour {
	public Entity entity;
	public Vector3 entityPosition;
	public bool hideAfterPickUp = true;
	public TouchMethod touchMethod;
	public bool isLocked;

	void OnTouchClick() {
		if (touchMethod == TouchMethod.OnTouchClick) {
			pickUpEntity();
		}
	}

	void OnTouchDown() {
		if (touchMethod == TouchMethod.OnTouchDown) {
			pickUpEntity();
		}
	}

	private void pickUpEntity() {
		if (isLocked) {
			return;
		}

		if (entity.isPossiblePickUp) {			
			if (entityPosition.x != 0 || entityPosition.y != 0 || entityPosition.z != 0) 
				entity.gameObject.transform.localPosition = entityPosition;
			if (hideAfterPickUp) 
				gameObject.SetActive(false);

			entity.gameObject.SetActive(true);
			entity.PickUp();
		}
	}
}