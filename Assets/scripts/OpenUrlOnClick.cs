using UnityEngine;
using System.Collections;

public class OpenUrlOnClick : MonoBehaviour {
	public string url;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick() {
		Application.OpenURL (url);
	}
}