using UnityEngine;
using System.Collections;

public class Defaults : MonoBehaviour {
	public int LevelID;

	// Use this for initialization
	void Start () {
		Constants.levelID = this.LevelID;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
