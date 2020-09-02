using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level003Paint : MonoBehaviour
{
	public GameObject key, doorlock, hand;
	Vector3 startPos;
	bool isCollised;
	public AudioSource clickAudio;
	// Use this for initialization
	void Start ()
	{
		startPos = transform.position;
		Invoke ("showHand", 0.6f);
	}

	void onOpenDoor ()
	{
		hand.SetActive (false);
	}

	void OnTouchDown (Vector2 pos)
	{
		clickAudio.Play ();
	
	}

	void showHand ()
	{
		hand.SetActive (true);
	}

	void OnTouchUp ()
	{
		if (!isCollised) {
			TweenPosition.Begin (gameObject, 0.4f, new Vector3 (transform.position.x, 0.7f, transform.position.z));
			GetComponent<BoxCollider2D> ().enabled = false;
			key.GetComponent<Entity> ().clickToPickUpTurnOn ();
			Invoke ("playBreakAudio", 0.4f);
			hand.GetComponent<Animator> ().SetTrigger ("toLock");
		} else
			TweenPosition.Begin (gameObject, 0.2f, startPos);
		
	}


	void playBreakAudio ()
	{
		GetComponent<AudioSource> ().Play ();
	}

	void OnTriggerEnter2D (Collider2D col)
	{	
		if (col.gameObject.name == "Numbers") {
			isCollised = true;
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.gameObject.name == "Numbers") {
			isCollised = false;
		}
	}

	public void openDoor ()
	{
		doorlock.SetActive (false);
		GameObject.Find ("Items").GetComponent<AudioSource> ().Play ();
		GameObject.Find ("Exit").GetComponent<Exit> ().openDelayed_1 ();
	}
	// Update is called once per frame
	void Update ()
	{
		 
	}
}
