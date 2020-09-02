using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level010Torch : MonoBehaviour
{
	public GameObject royale;
	public Vector3 startPos;
	int pautinaCount;
	// Use this for initialization
	void Awake ()
	{
	}

	void Start ()
	{
		startPos = transform.position;
		gameObject.SetActive (false);
		GetComponent<SpriteRenderer> ().enabled = true;

	}

	void OnTouchDown (Vector2 pos)
	{
		gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 1;
	}

	void OnTouchUp ()
	{
		TweenPosition.Begin (gameObject, 0.3f, startPos);
		gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 0;
	}


	void OnTriggerEnter2D (Collider2D col)
	{	
		if (col.gameObject.name.Contains ("Web")) {
			col.gameObject.transform.Find ("Fire").gameObject.SetActive (true);
			col.gameObject.GetComponent<Level010Pautina> ().hidePautina ();
			pautinaCount++;
			if (pautinaCount == 3) {
				Invoke ("hideRoyale", 1);
			}
		}
	}

	void hideRoyale ()
	{
		TweenPosition.Begin (royale, 0.5f, new Vector3 (royale.transform.position.x + 1, royale.transform.position.y, royale.transform.position.z));
		Invoke ("openDoor", 1);
	}

	public void openDoor ()
	{
		GameObject.Find ("Items").GetComponent<AudioSource> ().Play ();
		GameObject.Find ("Exit").GetComponent<Exit> ().openDelayed_1 ();
	}

	// Update is called once per frame
	void Update ()
	{
		
	}
}
