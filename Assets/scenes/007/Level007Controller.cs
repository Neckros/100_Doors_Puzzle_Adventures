using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level007Controller : MonoBehaviour
{
	public GameObject digitalLock, door;
	// Use this for initialization
	void Start ()
	{
	}

	void onOpenDoor ()
	{
		digitalLock.transform.parent = door.transform;
	}


	// Update is called once per frame
	void Update ()
	{
		
	}
}
