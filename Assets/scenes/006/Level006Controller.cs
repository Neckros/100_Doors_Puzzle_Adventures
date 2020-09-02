using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level006Controller : MonoBehaviour
{

	public GameObject[] arrFishki, arrColliders, lines;
	public GameObject bigCollider, objectCollider;
	public AudioSource magicAudio, swipeAudio;
	// Use this for initialization
	void Start ()
	{
	}



	public void scaleMinigame ()
	{
		TweenScale.Begin (gameObject, 0.2f, Vector3.one);
		TweenPosition.Begin (gameObject, 0.2f, new Vector3 (0, 0.7f, 0));
		bigCollider.SetActive (false);
		swipeAudio.Play ();
	}

	public void checkFinish ()
	{

		int truePosCount = 0;
		for (int i = 0; i < lines.Length; i++) {
			if (lines [i].GetComponent<Level006Line> ().isTruePos) {
				truePosCount++;
			}
		}
		if (truePosCount == lines.Length) {
			magicAudio.Play ();
			bigCollider.SetActive (true);
			Invoke ("hideMinigame", 1);
		} else
			bigCollider.SetActive (false);
	}

	void hideMinigame ()
	{
		TweenPosition.Begin (gameObject, 1, new Vector3 (5, 0, 0));
		Invoke ("openDoor", 1);
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
