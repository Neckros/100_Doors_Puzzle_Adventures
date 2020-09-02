using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenuScript : MonoBehaviour
{

	public GameObject menu;
	// Use this for initialization
	void Start ()
	{
		
	}

	public void OnClick ()
	{
		if (menu.name.Contains ("Pause"))
			menu.GetComponent<Settings> ().hideMenu ();
		else
			menu.GetComponent<Help> ().hideMenu ();

	}
	// Update is called once per frame
	void Update ()
	{
		
	}
}
