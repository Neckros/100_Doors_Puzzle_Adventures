using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level002Cell : MonoBehaviour
{
	Level002Controller controller;
	// Use this for initialization
	void Start ()
	{
		controller = GameObject.FindObjectOfType<Level002Controller> ().GetComponent<Level002Controller> ();
	}

	void OnTouchDown (Vector2 pos)
	{
		if (transform.parent.gameObject.GetComponent<Level002Line> ().controller.youwin)
			return;
		if (gameObject.GetComponent<SpriteRenderer> ().sprite.name == "green") {
			if (!controller.isContainerMoved)
				controller.clickToContainer ();
			gameObject.GetComponent<SpriteRenderer> ().sprite = transform.parent.gameObject.GetComponent<Level002Line> ().controller.sprRed;
			transform.parent.gameObject.GetComponent<Level002Line> ().controller.coinAudio.Play ();
			transform.parent.gameObject.GetComponent<Level002Line> ().controller.clickCount++;
			transform.parent.gameObject.GetComponent<Level002Line> ().controller.label.text = "" + transform.parent.gameObject.GetComponent<Level002Line> ().controller.clickCount + "/" + transform.parent.gameObject.GetComponent<Level002Line> ().controller.cellClickCount;
			if (transform.parent.gameObject.GetComponent<Level002Line> ().controller.clickCount % 10 == 0) {
				transform.parent.gameObject.GetComponent<Level002Line> ().controller.speed += 0.3f;
			}
			transform.parent.gameObject.GetComponent<Level002Line> ().controller.checkFinish ();
			transform.parent.gameObject.GetComponent<Level002Line> ().topLine.transform.Find ("collider").gameObject.SetActive (false);
		} else {
			transform.parent.gameObject.GetComponent<Level002Line> ().controller.gameOver ();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
