using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {
	static BackgroundMusic instance;

	public static BackgroundMusic getInstance() {
		return instance;
	}

	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
		gameObject.GetComponent<AudioSource>().Play();

		if (PlayerPrefs.GetInt("Music", 1) == 0) {
			playBgMusic(false);
		} else {
			playBgMusic(true);
		}
	}

	public void playBgMusic(bool isPlaying) {
		if (isPlaying) {
			PlayerPrefs.SetInt("Music", 1);
			gameObject.GetComponent<AudioSource>().enabled = true;
			gameObject.GetComponent<AudioSource>().volume = 1;
		} else {
			PlayerPrefs.SetInt("Music", 0);
			gameObject.GetComponent<AudioSource>().volume = 0;
			gameObject.GetComponent<AudioSource>().enabled = false;
		}
	}
	

}
