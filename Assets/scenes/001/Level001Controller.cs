using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level001Controller : MonoBehaviour
{
	public GameObject finish, start;
	public List<GameObject> arrVertical1, arrVertical2, arrVertical3, arrHorizontal;
	public AudioSource swipeAudio, magicAudio;
	// Use this for initialization
	void Start ()
	{
		
	}


	public void scaleMinigame ()
	{
		TweenScale.Begin (gameObject, 0.2f, new Vector3 (0.55f, 0.55f, 1));
		TweenPosition.Begin (gameObject, 0.2f, new Vector3 (0, 1, 0));
		swipeAudio.Play ();
	}

	public void finishLevel ()
	{
		magicAudio.Play ();
		for (int i = 0; i < arrVertical1.Count; i++) {
			arrVertical1 [i].GetComponent<CircleCollider2D> ().enabled = false;
		}
		for (int i = 0; i < arrVertical2.Count; i++) {
			arrVertical2 [i].GetComponent<CircleCollider2D> ().enabled = false;
		}
		for (int i = 0; i < arrVertical2.Count; i++) {
			arrVertical2 [i].GetComponent<CircleCollider2D> ().enabled = false;
		}
		for (int i = 0; i < arrHorizontal.Count; i++) {
			arrHorizontal [i].GetComponent<CircleCollider2D> ().enabled = false;
		}
		Invoke ("hideMinigame", 0.5f);
	}

	public void hideMinigame ()
	{
		TweenScale.Begin (gameObject, 0.5f, Vector3.zero);
		Invoke ("openDoor", 0.6f);
	}

	public void openDoor ()
	{
		gameObject.GetComponent<AudioSource> ().Play ();
		GameObject.Find ("Exit").GetComponent<Exit> ().openDelayed_1 ();
	}

	// Update is called once per frame
	void Update ()
	{
		
	}
}
