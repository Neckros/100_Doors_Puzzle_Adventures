using UnityEngine;
using System.Collections;

public class ButtonBack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick() {
		openMenu ();
	}
	private void openMenu(){
		ScenesManager.Instance.changeScene ("MainMenu");
	}
}


