using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level002Line : MonoBehaviour
{
	public GameObject topLine;
	public Level002Controller controller;
	public Vector3 startPos;
	// Use this for initialization
	void Start ()
	{
		controller = GameObject.FindObjectOfType<Level002Controller> ().GetComponent<Level002Controller> ();
		startPos = transform.localPosition;
		restartLine ();
	}

	public void restartLine ()
	{
		int randomIndex = Random.Range (0, transform.childCount - 1);
		for (int i = 0; i < transform.childCount; i++) {
			if (transform.GetChild (i).name != "collider")
				transform.GetChild (i).gameObject.GetComponent<SpriteRenderer> ().sprite = controller.sprRed;
		}
		transform.GetChild (randomIndex).gameObject.GetComponent<SpriteRenderer> ().sprite = controller.sprGreen;
	}
	// Update is called once per frame
	void Update ()
	{
		if (gameObject.transform.position.y < -2.5f) {
			bool isGameOver = false;
			for (int i = 0; i < transform.childCount; i++) {
				if (transform.GetChild (i).name != "collider") {
					if (transform.GetChild (i).gameObject.GetComponent<SpriteRenderer> ().sprite.name == "green") {
						controller.gameOver ();
						isGameOver = true;
						break;
					}
				}
			}
			if (isGameOver)
				return;
			transform.localPosition = new Vector3 (transform.localPosition.x, controller.previosMovedLine.transform.localPosition.y + 0.95f, transform.localPosition.z);
			topLine.transform.Find ("collider").gameObject.SetActive (true);
			controller.previosMovedLine.GetComponent<Level002Line> ().topLine = gameObject;
			controller.previosMovedLine = gameObject;
			restartLine ();
		}
	}
}
