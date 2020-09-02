using UnityEngine;
using System.Collections;
using System;

public class SkipLevel : MonoBehaviour
{
	GameObject menu_bg;
	Exit entry;
	// Use this for initialization
	void Start ()
	{
		menu_bg = GameObject.Find ("main_menu");
		entry = GameObject.Find ("Exit").GetComponent<Exit> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnClick ()
	{

		if (Time.timeScale == 0)
			Time.timeScale = 1;
		
		GameObject.Find ("PauseMenu").GetComponent<Settings> ().hideMenu ();
		Invoke ("showSkipLevel", 0.5f);
		GameObject.Find ("clickAudio").GetComponent<AudioSource> ().Play ();
		if (Const.isDesktop) {
			return;		
		}		
		try {
			if ((entry.getLevelId () + 1) % 3 != 0) {
				if (AdsManager.Instance.isInterstitialRedy ()) {
					AdsManager.Instance.showInterstitialAds ();
				} else {
					AdsManager.Instance.loadInterstitial ();	
				}
			}
						

		} catch (Exception e) {
			Debug.Log ("Error in SkipLevel.class");
		}
	}

	private void showSkipLevel ()
	{
		
		if (ProgressManager.Instance.getLevelState (entry.getLevelId () + 1) != (int)ProgressManager.LevelState.state.Opened) {
			ProgressManager.Instance.setLevelState (entry.getLevelId () + 1, ProgressManager.LevelState.state.Available);

		}

		
		
		AudioManager.Instance.bgSoundPause ();
		bool isNextLevelLoaded = ProgressManager.Instance.loadLevel (entry.getLevelId () + 1);
		
		
		if (!isNextLevelLoaded) {			
			ScenesManager.Instance.changeScene ("MainMenu");
		}
	}
}
