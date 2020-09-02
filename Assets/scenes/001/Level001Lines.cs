using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level001Lines : MonoBehaviour
{

	Level001Controller controller;
	// Use this for initialization
	void Start ()
	{
		controller = GameObject.FindObjectOfType<Level001Controller> ().GetComponent<Level001Controller> ();
	}

	void OnTriggerEnter2D (Collider2D col)
	{	
		if (gameObject.name.Contains ("line") && gameObject.name.Contains ("1") && col.gameObject.name.Contains ("circle")) {
			if (!controller.arrVertical1.Contains (col.gameObject))
				controller.arrVertical1.Add (col.gameObject);
			col.gameObject.GetComponent<Level001Ball> ().arrCurrentVertLineBalls = controller.arrVertical1;
		}
		if (gameObject.name.Contains ("line") && gameObject.name.Contains ("2") && col.gameObject.name.Contains ("circle")) {
			if (!controller.arrVertical2.Contains (col.gameObject))
				controller.arrVertical2.Add (col.gameObject);
			col.gameObject.GetComponent<Level001Ball> ().arrCurrentVertLineBalls = controller.arrVertical2;
		}
		if (gameObject.name.Contains ("line") && gameObject.name.Contains ("3") && col.gameObject.name.Contains ("circle")) {
			if (!controller.arrVertical3.Contains (col.gameObject))
				controller.arrVertical3.Add (col.gameObject);
			col.gameObject.GetComponent<Level001Ball> ().arrCurrentVertLineBalls = controller.arrVertical3;
		}
		if (gameObject.name.Contains ("lineHor") && col.gameObject.name.Contains ("circle")) {
			if (!controller.arrHorizontal.Contains (col.gameObject))
				controller.arrHorizontal.Add (col.gameObject);
			col.gameObject.GetComponent<Level001Ball> ().arrCurrentHorLineBalls = controller.arrHorizontal;
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (gameObject.name.Contains ("line") && gameObject.name.Contains ("1") && col.gameObject.name.Contains ("circle")) {
			controller.arrVertical1.Remove (col.gameObject);
			col.gameObject.GetComponent<Level001Ball> ().arrCurrentVertLineBalls = controller.arrVertical1;
		}
		if (gameObject.name.Contains ("line") && gameObject.name.Contains ("2") && col.gameObject.name.Contains ("circle")) {
			controller.arrVertical2.Remove (col.gameObject);
			col.gameObject.GetComponent<Level001Ball> ().arrCurrentVertLineBalls = controller.arrVertical2;
		}
		if (gameObject.name.Contains ("line") && gameObject.name.Contains ("3") && col.gameObject.name.Contains ("circle")) {
			controller.arrVertical3.Remove (col.gameObject);
			col.gameObject.GetComponent<Level001Ball> ().arrCurrentVertLineBalls = controller.arrVertical3;
		}
		if (gameObject.name.Contains ("lineHor") && col.gameObject.name.Contains ("circle")) {
			controller.arrHorizontal.Remove (col.gameObject);
			col.gameObject.GetComponent<Level001Ball> ().arrCurrentHorLineBalls = controller.arrHorizontal;
		}
	}
	// Update is called once per frame
	void Update ()
	{
		
	}
}
