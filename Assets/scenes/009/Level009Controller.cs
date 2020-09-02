using UnityEngine;
using System.Collections;

public class Level009Controller : MonoBehaviour
{

	public GameObject[] cells;
	public GameObject content, littleDoor, key, doorlock, horse;
	public AudioSource magicAudio;
	// Use this for initialization
	void Start ()
	{

	}


	public void openLittleDoor ()
	{
		TweenScale.Begin (littleDoor, 0.6f, new Vector3 (0, 0, 1));
		key.GetComponent<BoxCollider2D> ().enabled = true;
		key.transform.position = new Vector3 (key.transform.position.x, key.transform.position.y, -1);
		magicAudio.Play ();
//		Invoke ("hideMinigame");
	}

	public void clickToKey ()
	{
		hideMinigame ();
	}

	private void hideMinigame ()
	{
		TweenPosition.Begin (content, 1, new Vector3 (5, 0, 0));
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
