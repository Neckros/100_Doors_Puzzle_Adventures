using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Digital_lock_controller : MonoBehaviour
{
	public GameObject toolboxAudio, lock_collider, errorAudio, magicAudio, items, pass_indicator;
	public string password;
	public Text text;
	private Vector3 startScale, startPos, lock_collider_startPos;
	private bool isScaled, isError;
	public bool dontOpenDoor = false;
	public AudioSource swipeAudio;
	int startSortingInLayer;
	// Use this for initialization
	void Start ()
	{
		startScale = gameObject.transform.lossyScale;
		startPos = gameObject.transform.localPosition;
		lock_collider_startPos = lock_collider.transform.localPosition;
		startSortingInLayer = gameObject.GetComponent<SpriteRenderer> ().sortingOrder;
	}

	public void onNumClick (GameObject go)
	{
		if (isError)
			return;
		gameObject.GetComponent<AudioSource> ().Play ();
		if (go.name == "back") {
			if (text.text.Length != 0) {
				text.text = text.text.Remove (text.text.Length - 1, 1); 
			}
			return;
		}
		if (go.name != "C") {
			text.text += go.name.ToString ();
			if (text.text.Length == password.Length && password != text.text) {
				isError = true;
				errorAudio.GetComponent<AudioSource> ().Play ();
				Invoke ("reset", 0.5f);
			}
		}
		if (password == text.text) {
			lock_collider.GetComponent<TouchListener> ().isTouch = false;
			magicAudio.GetComponent<AudioSource> ().Play ();
			Invoke ("open", 0.5f);
			pass_indicator.SetActive (true);
			return;
		}

		if (go.name == "C") {
			text.text = "";
		}


	}

	void reset ()
	{
		text.text = "";
		isError = false;
	}

	void open ()
	{
		if (dontOpenDoor) {
			TweenScale.Begin (gameObject, 0.3f, startScale);
			TweenPosition.Begin (gameObject, 0.3f, new Vector3 (startPos.x, startPos.y, 0));
			TweenPosition.Begin (lock_collider, 0, lock_collider_startPos);
		} else {
			isScaled = true;
			isError = false;
			onClick ();
		}
//		text.text = "";
		if (items != null) {
			items.SendMessage ("onOpenDoor");
			if (!dontOpenDoor)
				Invoke ("openDoor", 2f);
		} else
			Invoke ("openDoor", 1f);
	}

	public void onClick ()
	{
		if (!isScaled) {
			TweenScale.Begin (gameObject, 0.3f, new Vector3 (1.4f, 1.4f, 1));
			TweenPosition.Begin (gameObject, 0.3f, new Vector3 (0, 0.8f, gameObject.transform.position.z));
			TweenPosition.Begin (lock_collider, 0, new Vector3 (0, 1, 0.1f));
			gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		} else {
			TweenScale.Begin (gameObject, 0.3f, startScale);
			TweenPosition.Begin (gameObject, 0.3f, startPos);
			TweenPosition.Begin (lock_collider, 0, lock_collider_startPos);
			Invoke ("setStartSortingLayer", 0.3f);

		}
		swipeAudio.Play ();
		isScaled = !isScaled;
	}

	void setStartSortingLayer ()
	{
		gameObject.GetComponent<SpriteRenderer> ().sortingOrder = startSortingInLayer;
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
