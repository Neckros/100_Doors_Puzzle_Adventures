using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level006ObjectCollider : MonoBehaviour
{
	public GameObject parentObj;
	public List<GameObject> arrCollisedPoints = new List<GameObject> ();
	// Use this for initialization
	void Start ()
	{
		
	}

	void OnTriggerEnter2D (Collider2D col)
	{	
		if (col.gameObject.name.Contains ("col")) {
//			if (col.gameObject.GetComponent<Level006Collider> ().isEmpty) {
			if (!arrCollisedPoints.Contains (col.gameObject) && col.gameObject != parentObj)
				arrCollisedPoints.Add (col.gameObject);
//			} else {
//				if (col.gameObject != parentObj) {
//					TweenPosition.Begin (gameObject, 0, transform.localPosition);
//				}
//			}
		}


	}
	// Update is called once per frame
	void Update ()
	{
		
	}
}
