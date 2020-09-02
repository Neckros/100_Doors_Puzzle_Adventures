using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level010Venik : MonoBehaviour
{
	Vector3 startPos;
	public GameObject torch;
	public AudioSource fireAudio;
	bool isSpiderHide;
	// Use this for initialization
	void Start ()
	{
		startPos = transform.position;
//		torch.GetComponent<Level010Torch> ().startPos = torch.transform.position;
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
		if (col.gameObject.name == "Spider") {
			TweenPosition.Begin (col.gameObject, 1f, new Vector3 (col.gameObject.transform.position.x - 2, col.gameObject.transform.position.y + 1.5f, col.gameObject.transform.position.z));
			col.gameObject.GetComponent<AudioSource> ().Play ();
			isSpiderHide = true;
		}
		if (col.gameObject.name.Contains ("Candle") && isSpiderHide) {
			torch.transform.position = gameObject.transform.position + new Vector3 (0, 0.5f, 0);
			gameObject.SetActive (false);
			torch.SetActive (true);
			fireAudio.Play ();

		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.gameObject.name == "name_obj") {

		}
	}

	// Update is called once per frame
	void Update ()
	{
		
	}
}
