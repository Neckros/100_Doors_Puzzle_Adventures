using UnityEngine;
using System.Collections;

public class EntityPutInPosition : MonoBehaviour {
	private GameObject entity;
	public Vector3 position;
	
	public void removeFromInventoryInPossition() {
		entity = GameObject.Find("Inventory").GetComponent<Inventory>().getActiveEntity();
		entity.GetComponent<Entity>().remove();
		entity.GetComponent<Entity>().putTooPosition(position);
		entity.SetActive(true);
	}

	public void execute() {
		removeFromInventoryInPossition();
	}
}
