using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level010Pautina : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}


	public void hidePautina ()
	{
		TweenColor.Begin (gameObject, 1, new Color (255, 255, 255, 0));
		Invoke ("disablePautina", 2);
	}

	void disablePautina ()
	{
		gameObject.SetActive (false);
	}
	// Update is called once per frame
	void Update ()
	{
		
	}
}
