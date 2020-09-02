using UnityEngine;
using System.Collections;
using System;

public class MainMenuBackButtom : MonoBehaviour
{
	bool exit;
	float time;
	int clickCount;
	public AudioSource clickAudio;
	// Use this for initialization
	void Start ()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	// Update is called once per frame
	void Update ()
	{
		try {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				exit = true;
				clickCount++;
				if(!clickAudio.isPlaying){
				clickAudio.Play();
				}
			}

		} catch (Exception e) {
			Debug.Log ("ExitGame.class Error");
		}
		if (exit) {
			time += Time.deltaTime;
		}
		if (time > 1) {
			exit = false;
			time = 0;
			clickCount = 0;
		} else {
			if (clickCount == 2) {
				Application.Quit ();
			}
		}
	}
}
