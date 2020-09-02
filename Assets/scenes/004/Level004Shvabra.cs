using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level004Shvabra : MonoBehaviour
{

	public GameObject doorlock;
	Vector3 startPos;
	public AudioSource clickAudio, swordAudio;

	// Use this for initialization
	void Start ()
	{
		startPos = transform.position;


	}

	void OnTouchDown (Vector2 pos)
	{
		clickAudio.Play ();
		GetComponent<SpriteRenderer> ().sortingOrder = 1;
	}

	void OnTouchUp ()
	{
		GetComponent<SpriteRenderer> ().sortingOrder = 0;
		TweenPosition.Begin (gameObject, 0.5f, startPos);
	}

	void OnTriggerEnter2D (Collider2D col)
	{	
		if (col.gameObject.name == "key2") {
			swordAudio.Play ();
			gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			TweenPosition.Begin (col.gameObject, 1f, new Vector3 (0, -0.8f, 0));
			TweenRotation.Begin (col.gameObject, 1f, Quaternion.Euler (new Vector3 (0, 0, 359)));
			col.gameObject.GetComponent<Entity> ().clickToPickUpTurnOn ();
			Invoke ("playClickAudio", 1);
		}
	}

	void playClickAudio ()
	{
		clickAudio.Play ();
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.gameObject.name == "key2") {
			
		}
	}

	public void openDoor ()
	{
		doorlock.SetActive (false);
		gameObject.GetComponent<AudioSource> ().Play ();
		GameObject.Find ("Exit").GetComponent<Exit> ().openDelayed_1 ();
	}
	// Update is called once per frame
	void Update ()
	{
		
	}
}
