using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour
{
	public bool clickToPickUp = true;
	public bool soundOnAction = true;
	public bool originalSizeInInventory = false;
	public bool useCustomSound;
	public bool scaleOnTouchDown;
	public bool isDragged;
	public Vector2 dragOffset;
	[HideInInspector]
	public bool
		isDragPosItem;
	private Inventory inv;

	private Inventory inventory {
		get { 
			if (!inv)
				inv = GameObject.Find ("Inventory").GetComponent<Inventory> ();
			return inv;
		}
	}

	private bool isInInventory;
	private Vector2 size;
	private SpriteRenderer spriteRenderer;

	void Awake ()
	{
		isInInventory = false;
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		size = new Vector2 ();
		isDragPosItem = dragOffset != Vector2.zero;
	}

	//	void OnTouchClick ()
	//	{
	void OnTouchUp ()
	{
		if (clickToPickUp) {
			PickUp ();
		}
	}

	public bool PickUp ()
	{
		if (!isInInventory) {
			bool isActive = gameObject.activeSelf;
			gameObject.SetActive (true);
			if (inventory.push (this)) {
				isInInventory = true;
				touchable = false;
				if (spriteRenderer.sortingOrder < 1) {
					spriteRenderer.sortingOrder = 1;
				}
				if (GetComponent<Rigidbody2D> ())
					GetComponent<Rigidbody2D> ().isKinematic = true;
				gameObject.SendMessage ("OnInventoryPickUp", SendMessageOptions.DontRequireReceiver);

				return true;
			}
			gameObject.SetActive (isActive);
		}
		return false;
	}

	public void pickUp ()
	{
		PickUp ();
	}

	public void remove ()
	{
		removeFromInventory ();
	}

	public void clickToPickUpTurnOn ()
	{
		clickToPickUp = true;
	}

	public void clickToPickUpTurnOff ()
	{
		clickToPickUp = false;
	}

	public bool removeFromInventory ()
	{
		if (isInInventory) {
			inventory.removeActiveEntity ();
			isInInventory = false;
			spriteRenderer.sortingOrder = 0;
			if (GetComponent<Rigidbody2D> ())
				GetComponent<Rigidbody2D> ().isKinematic = false;
			gameObject.SendMessage ("OnInventoryRemove", SendMessageOptions.DontRequireReceiver);
			return true;
		}

		return false;
	}

	public bool isPossiblePickUp {
		get{ return !isInInventory && inventory.isPossiblePickUp; }
	}

	// TODO: this is not work...
	public bool merge (Entity entity)
	{
		this.removeFromInventory ();
		entity.removeFromInventory ();
		return false;
	}

	public bool touchable {
		set { 
			if (gameObject.GetComponent<Collider2D> ()) {
				if (!value) {
					//	print("touchable = false");
					if (size.x == 0) {
						size = ((BoxCollider2D)gameObject.GetComponent<Collider2D> ()).size;
					}
					((BoxCollider2D)gameObject.GetComponent<Collider2D> ()).size = new Vector2 (0, 0);
				} else {
					//	print("touchable = true");				
					((BoxCollider2D)gameObject.GetComponent<Collider2D> ()).size = size;				
				}
			}
		}
	}

	public void putTooPosition (Vector3 vec)
	{
		gameObject.transform.localPosition = vec;
		if (isInInventory) {
			inventory.removeActiveEntity ();
			isInInventory = false;
			spriteRenderer.sortingOrder = 0;
			if (GetComponent<Rigidbody2D> ())
				GetComponent<Rigidbody2D> ().isKinematic = false;
		}


	
	}

	public bool IsInInventory {
		get {
			return this.isInInventory;
		}
	}
}
