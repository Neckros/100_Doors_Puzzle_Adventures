using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
	private InventorySlot[] slots;
	List<GameObject> arrDoorNumber = new List<GameObject> ();
	GameObject doorNumber;

	void Awake ()
	{	
		slots = gameObject.GetComponentsInChildren<InventorySlot> ();


//		obj.GetComponent<UILabel> ().text = "DOOR " + ScenesManager.getIdByLevelName (Application.loadedLevelName);//GameObject.Find ("Exit").GetComponent<Exit> ().getLevelId ();
	}

	void Start ()
	{
		for (int i = 0; i < GameObject.FindGameObjectsWithTag ("doorNumber").Length; i++) {
			if (GameObject.FindGameObjectsWithTag ("doorNumber") [i].activeSelf) {
				doorNumber = GameObject.FindGameObjectsWithTag ("doorNumber") [i];
			}
		}
//		arrDoorNumber = GameObject.FindGameObjectsWithTag ("doorNumber").;
//		for (int i = 0; i < arrDoorNumber.Count; i++) {
//			if (arrDoorNumber [i].activeSelf)
		doorNumber.GetComponent<UILabel> ().text = doorNumber.GetComponent<UILabel> ().text + ScenesManager.getIdByLevelName (Application.loadedLevelName);
//		}
	}

	public bool push (Entity entity)
	{	
		InventorySlot slot = getEmptySlot ();
		if (slot != null) {
			slot.push (entity);
			GetComponent<AudioSource> ().Play ();
			return true;
		} 

		return false;
	}

	public InventorySlot getEmptySlot ()
	{
		foreach (InventorySlot slot in slots)
			if (slot.isEmpty ())
				return slot;

		return null;
	}

	private InventorySlot getActiveSlot ()
	{
		foreach (InventorySlot slot in slots)
			if (slot.IsActive)
				return slot;

		return null;
	}

	public GameObject getActiveEntity ()
	{
		return getActiveSlot ().get ().gameObject;
	}

	public GameObject removeActiveEntity ()
	{
		return getActiveSlot ().remove ().gameObject;
	}

	public bool isPossiblePickUp {
		get { return getEmptySlot (); }
	}

	public InventorySlot[] getEntity {
		get { return slots; }
	}
}