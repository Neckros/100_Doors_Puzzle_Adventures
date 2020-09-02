using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundMusic : MonoBehaviour
{
	public GameObject bgMusicDesignation, checkmark;

	void Start ()
	{
		if (PlayerPrefs.GetInt ("Sound", 1) == 0) {
			checkmark.SetActive (true);
			AudioListener.volume = 0;
			bgMusicDesignation.SetActive (false);
		} else if (PlayerPrefs.GetInt ("Sound", 1) == 1) {
			checkmark.SetActive (false);
			AudioListener.volume = 1;
			bgMusicDesignation.SetActive (true);
			AudioManager.Instance.bgSoundOn ();
		} else if (PlayerPrefs.GetInt ("Sound", 1) == 2) {
			checkmark.SetActive (false);
			AudioListener.volume = 1;
			bgMusicDesignation.SetActive (false);
			AudioManager.Instance.bgSoundPause ();
		} 
	}

	void Update ()
	{

	}

	void OnClick ()
	{
		if (PlayerPrefs.GetInt ("Sound", 1) == 0) {
			PlayerPrefs.SetInt ("Sound", 1);
			AudioListener.volume = 1;
			checkmark.SetActive (false);
			bgMusicDesignation.SetActive (true);
			AudioManager.Instance.bgSoundOn ();
			return;
		} else if (PlayerPrefs.GetInt ("Sound", 1) == 1) {
			PlayerPrefs.SetInt ("Sound", 2);
			AudioListener.volume = 1;
			checkmark.SetActive (false);
			bgMusicDesignation.SetActive (false);
			AudioManager.Instance.bgSoundPause ();
			return;

		} else if (PlayerPrefs.GetInt ("Sound", 1) == 2) {
			PlayerPrefs.SetInt ("Sound", 0);
			AudioListener.volume = 0;
			bgMusicDesignation.SetActive (false);
			checkmark.SetActive (true);
		}

	}

}
