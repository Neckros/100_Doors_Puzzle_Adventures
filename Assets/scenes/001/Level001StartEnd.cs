using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level001StartEnd : MonoBehaviour
{

	public bool isEmpty;
	// Use this for initialization
	void Start ()
	{
		isEmpty = true;
	}

	void OnTriggerEnter2D (Collider2D col)
	{	
		if (col.gameObject.name.Contains ("circle")) {
			isEmpty = false;
		}
		if (gameObject.name == "finish" && col.gameObject.name.Contains ("main_circle")) {
			Invoke ("playMagicAudio", 0.5f);
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.gameObject.name.Contains ("circle")) {
			isEmpty = true;
		}

	}

	void playMagicAudio ()
	{
		GameObject.Find ("Items").GetComponent<Level001Controller> ().finishLevel ();
	}
	// Update is called once per frame
	void Update ()
	{
		
	}
}
