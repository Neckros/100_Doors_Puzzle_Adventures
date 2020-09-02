using UnityEngine;
using System.Collections;
using System;

public class ButtonBackGoMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		try{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			ScenesManager.Instance.changeScene ("MainMenu");		
		}
		}catch (Exception e) {
			Debug.Log ("ButtonBackGoMenu.class Error");
	}
}
}