using UnityEngine;
using System.Collections;

public class Level009CollisionDetector : MonoBehaviour
{


	public GameObject lastCollideObject;
	// Use this for initialization
	void Start ()
	{
		lastCollideObject = null;
	
	}
	void OnTriggerEnter2D (Collider2D col)
	{	
		if (col.gameObject.name.Substring (0, 4) == "cell") {
			lastCollideObject = col.gameObject;
		}
	}
	public GameObject getLastCollideObject ()
	{
		return lastCollideObject;
	}
	// Update is called once per frame
	void Update ()
	{
	
	}
}
