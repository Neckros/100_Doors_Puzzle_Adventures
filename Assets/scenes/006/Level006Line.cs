using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level006Line : MonoBehaviour
{
	public List<GameObject> arrObjects = new List<GameObject> ();
	public bool isTruePos;
	// Use this for initialization
	void Start ()
	{
		
	}

	void OnTriggerEnter2D (Collider2D col)
	{	
		if (col.gameObject.name.Contains ("eat") || col.gameObject.name.Contains ("animal") || col.gameObject.name.Contains ("kich") || col.gameObject.name.Contains ("clothes")) {
			if (!arrObjects.Contains (col.gameObject)) {
				arrObjects.Add (col.gameObject);
				col.gameObject.GetComponent<Level006Object> ().collisionLine = gameObject;
				checkFinish ();
			}
			
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.gameObject.name.Contains ("eat") || col.gameObject.name.Contains ("animal") || col.gameObject.name.Contains ("kich") || col.gameObject.name.Contains ("clothes")) {
			if (arrObjects.Contains (col.gameObject))
				arrObjects.Remove (col.gameObject);
		}
	}

	void checkFinish ()
	{
		int truePosCount = 1;
		for (int i = 0; i < arrObjects.Count; i++) {
			if (i + 1 < arrObjects.Count)
			if (arrObjects [i].name.Contains (arrObjects [i + 1].name.Substring (0, 3))) {
				truePosCount++;
			}
		}
		if (truePosCount == 4)
			isTruePos = true;
	}
	// Update is called once per frame
	void Update ()
	{
		
	}
}
