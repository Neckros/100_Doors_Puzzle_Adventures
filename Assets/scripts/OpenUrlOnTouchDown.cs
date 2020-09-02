using UnityEngine;
using System.Collections;

public class OpenUrlOnTouchDown : MonoBehaviour {
	public string url;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTouchDown (Vector2 pos)
	{
		Application.OpenURL (url);
	}
}
