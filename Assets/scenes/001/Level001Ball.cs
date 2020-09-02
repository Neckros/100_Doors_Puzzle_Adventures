using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level001Ball : MonoBehaviour
{
	Level001Controller controller;
	public List<GameObject> arrCurrentVertLineBalls, arrCurrentHorLineBalls;
	// Use this for initialization
	void Start ()
	{
		controller = GameObject.FindObjectOfType<Level001Controller> ().GetComponent<Level001Controller> ();
	}

	public void swipeLeft ()
	{
		if (controller.start.GetComponent<Level001StartEnd> ().isEmpty) {
			for (int i = 0; i < controller.arrHorizontal.Count; i++) {
				TweenPosition.Begin (controller.arrHorizontal [i], 0.3f, new Vector3 (controller.arrHorizontal [i].transform.localPosition.x - 1.4f, controller.arrHorizontal [i].transform.localPosition.y, controller.arrHorizontal [i].transform.localPosition.z));
			}
		}
		controller.swipeAudio.Play ();
	}

	public void swipeRight ()
	{
		if (controller.finish.GetComponent<Level001StartEnd> ().isEmpty) {
			for (int i = 0; i < controller.arrHorizontal.Count; i++) {
				TweenPosition.Begin (controller.arrHorizontal [i], 0.3f, new Vector3 (controller.arrHorizontal [i].transform.localPosition.x + 1.4f, controller.arrHorizontal [i].transform.localPosition.y, controller.arrHorizontal [i].transform.localPosition.z));
			}
		}
		controller.swipeAudio.Play ();
	}

	public void swipeUp (GameObject ball)
	{
		bool isEmpty = false;
		for (int i = 0; i < ball.GetComponent<Level001Ball> ().arrCurrentVertLineBalls.Count; i++) {
			if (ball.GetComponent<Level001Ball> ().arrCurrentVertLineBalls [i].transform.localPosition.y > -0.45f) {
				isEmpty = false;
				break;
			} else
				isEmpty = true;
		}
		if (isEmpty) {
			for (int i = 0; i < ball.GetComponent<Level001Ball> ().arrCurrentVertLineBalls.Count; i++) {
				TweenPosition.Begin (ball.GetComponent<Level001Ball> ().arrCurrentVertLineBalls [i], 0.3f, new Vector3 (ball.GetComponent<Level001Ball> ().arrCurrentVertLineBalls [i].transform.localPosition.x, 
					ball.GetComponent<Level001Ball> ().arrCurrentVertLineBalls [i].transform.localPosition.y + 2.1f, ball.GetComponent<Level001Ball> ().arrCurrentVertLineBalls [i].transform.localPosition.z));
			}
		}
		controller.swipeAudio.Play ();
	}

	public void swipeDown (GameObject ball)
	{
		bool isEmpty = false;
		for (int i = 0; i < ball.GetComponent<Level001Ball> ().arrCurrentVertLineBalls.Count; i++) {
			if (ball.GetComponent<Level001Ball> ().arrCurrentVertLineBalls [i].transform.localPosition.y < -2.2f) {
				isEmpty = false;
				break;
			} else
				isEmpty = true;
		}
		if (isEmpty) {
			for (int i = 0; i < ball.GetComponent<Level001Ball> ().arrCurrentVertLineBalls.Count; i++) {
				TweenPosition.Begin (ball.GetComponent<Level001Ball> ().arrCurrentVertLineBalls [i], 0.3f, new Vector3 (ball.GetComponent<Level001Ball> ().arrCurrentVertLineBalls [i].transform.localPosition.x, 
					ball.GetComponent<Level001Ball> ().arrCurrentVertLineBalls [i].transform.localPosition.y - 2.1f, ball.GetComponent<Level001Ball> ().arrCurrentVertLineBalls [i].transform.localPosition.z));
			}
		}
		controller.swipeAudio.Play ();
	}
	// Update is called once per frame
	void Update ()
	{
		
	}
}
