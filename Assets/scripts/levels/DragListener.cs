using UnityEngine;
using System.Collections;

public class DragListener : MonoBehaviour
{
	public bool isTouch = true;
	public bool lockX, lockY;
	public Vector2 dragAreaFrom, dragAreaTo;
	private Vector2 objectStartPos;
	private bool isLimited;
	private Vector3 touchDragStartPos;
	private Vector3 dragStartPos;
	public AudioSource movingAudio;

	void Awake ()
	{
		objectStartPos = transform.position;
	}

	void OnTouchDown (Vector2 pos)
	{
		if (!isTouch)
			return;

		dragStartPos = gameObject.transform.position;
		touchDragStartPos = dragStartPos - Camera.main.ScreenToWorldPoint (pos);
		isLimited = isLimit ();
	}

	void OnTouchDrag (Vector2 pos)
	{ 
		if (!isTouch)
			return;

		if (GetComponent<Collider2D> ().enabled) {
			Vector3 targetPos = Camera.main.ScreenToWorldPoint (pos) + touchDragStartPos;
			if (isLimited) {
				if (!lockX)
					targetPos.x = Mathf.Clamp (targetPos.x, objectStartPos.x + dragAreaFrom.x, objectStartPos.x + dragAreaTo.x);
				if (!lockY)
					targetPos.y = Mathf.Clamp (targetPos.y, objectStartPos.y + dragAreaFrom.y, objectStartPos.y + dragAreaTo.y);
			}
			if (lockX)
				targetPos.x = dragStartPos.x;
			if (lockY)
				targetPos.y = dragStartPos.y;
			if (movingAudio != null && !movingAudio.isPlaying)
				movingAudio.Play ();
			transform.position = targetPos;
		}
	}

	void OnTouchUp ()
	{
		if (!isTouch)
			return;

	}

	private bool isLimit ()
	{
		return dragAreaFrom != Vector2.zero || dragAreaTo != Vector2.zero;
	}
}
 