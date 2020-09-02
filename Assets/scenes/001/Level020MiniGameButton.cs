using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level020MiniGameButton : MonoBehaviour
{
	public GameObject miniGame, deleteObj, notifyObject;
	public Vector3 gamePosition, gameScale;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTouchDown (Vector2 pos)
	{
		miniGame.SetActive (true);
		TweenPosition.Begin (miniGame, 0.2f, new Vector3 (gamePosition.x, gamePosition.y, miniGame.transform.position.z));
		TweenScale.Begin (miniGame, 0.2f, gameScale);
		gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		gameObject.GetComponent<AudioSource> ().Play ();
		if (notifyObject != null)
			notifyObject.SendMessage ("onScaleGame");
		if (deleteObj != null) {
			deleteObj.SetActive (false);
		}
	}
}
