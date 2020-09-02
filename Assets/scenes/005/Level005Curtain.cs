using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level005Curtain : MonoBehaviour
{
	public GameObject curtainLeft, curtainRight, arrowContainer;
	public AudioSource swipeAudio, toolboxAudio;
	bool isSwiped;
	private Vector2 swipeStartPos;
	Level005Controller controller;
	// Use this for initialization
	void Start ()
	{
		controller = GameObject.FindObjectOfType<Level005Controller> ().GetComponent<Level005Controller> ();
	}

	void swipeLeft ()
	{
		swipeAudio.Play ();
		TweenScale.Begin (gameObject, 0.5f, new Vector3 (0, 1, 1));
		TweenColor.Begin (gameObject, 0.5f, new Color (255, 255, 255, 0));
		Invoke ("hideLeftCurtain", 0.4f);
		arrowContainer.SetActive (false);
	}

	void hideLeftCurtain ()
	{
		curtainLeft.SetActive (true);
		gameObject.SetActive (false);
		arrowContainer.SetActive (true);
		arrowContainer.transform.localScale = new Vector3 (arrowContainer.transform.localScale.x * -1, arrowContainer.transform.localScale.y, arrowContainer.transform.localScale.z);
	}

	void swipeRight ()
	{
		swipeAudio.Play ();
		arrowContainer.SetActive (false);
		TweenScale.Begin (gameObject, 0.5f, new Vector3 (0, 1, 1));

		TweenColor.Begin (gameObject, 0.5f, new Color (255, 255, 255, 0));
		Invoke ("hideRightCurtain", 0.4f);
	}

	void hideRightCurtain ()
	{
		curtainRight.SetActive (true);
		gameObject.SetActive (false);
		Invoke ("openDoor", 1);
	}

	void OnTouchDown (Vector2 pos)
	{
		swipeStartPos = pos;
	}

	void OnTouchUp ()
	{
		isSwiped = false;
	}

	void OnTouchDrag (Vector2 pos)
	{
		if (isSwiped) {
			return;
		}
		Vector2 swipeDiffPos = pos - swipeStartPos;
		float distance = Vector2.Distance (pos, swipeStartPos);
		float angle = Vector2.Angle (swipeDiffPos, new Vector2 (0, 1));
		if (pos.x < swipeStartPos.x) {
			angle = 360 - angle;
		}

		if (distance > 50f) {
			if (angle <= 135 && angle > 45 && !controller.isNeedSwipeLeft) {
				swipeRight ();
				isSwiped = true;
			}
	
			if (angle <= 315 && angle > 225 && controller.isNeedSwipeLeft) {
				swipeLeft ();
				controller.isNeedSwipeLeft = false;
				isSwiped = true;
			}
		}

	}

	public void openDoor ()
	{
		toolboxAudio.GetComponent<AudioSource> ().Play ();
		GameObject.Find ("Exit").GetComponent<Exit> ().openDelayed_1 ();
	}

	// Update is called once per frame
	void Update ()
	{
		
	}
}
