using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
	private static AudioManager inst;
	public GameObject bgSound;
	public List<AudioSource> arrGameBgAudioSource = new List<AudioSource> ();
	public List<AudioSource> arrMainMenuBgAudioSource = new List<AudioSource> ();
	public int index = 0;
	bool isBgSoundPause;

	public static AudioManager Instance {
		get {
			if (inst == null) {
				GameObject container = (GameObject)Instantiate (Resources.Load ("AudioManager"));
				container.name = "_AudioManager";
				DontDestroyOnLoad (container);
				inst = container.GetComponent<AudioManager> ();

			}
			return inst;
		}

	}

	void Start ()
	{
		createBgSoundObject ();
	}

	void Awake ()
	{
		for (int i = 0; i < GetComponents<AudioSource> ().Length; i++) {
			GetComponents<AudioSource> () [i].ignoreListenerPause = true;
			GetComponents<AudioSource> () [i].ignoreListenerVolume = true;
			arrMainMenuBgAudioSource.Add (GetComponents<AudioSource> () [i]);
		}
	}

	void createBgSoundObject ()
	{
		if (arrGameBgAudioSource.Count == 0) {
			bgSound = (GameObject)Instantiate (Resources.Load ("BgAudio"));
			for (int i = 0; i < bgSound.GetComponents<AudioSource> ().Length; i++) {
				bgSound.GetComponents<AudioSource> () [i].ignoreListenerPause = true;
				bgSound.GetComponents<AudioSource> () [i].ignoreListenerVolume = true;
				arrGameBgAudioSource.Add (bgSound.GetComponents<AudioSource> () [i]);
			}
		}
	}

	//	void playBackground ()
	//	{
	//		if (!GetComponent<AudioSource> ().isPlaying)
	//			GetComponent<AudioSource> ().Play ();
	//
	//		AudioListener.pause = false;
	//
	//	}
	//
	//	public void pauseBackground ()
	//	{
	//		GetComponent<AudioSource> ().Pause ();
	//		AudioListener.pause = true;
	//
	//	}
	//
	//	public void stopBackground ()
	//	{
	//		GetComponent<AudioSource> ().Stop ();
	//	}

	public void updatePlaying ()
	{
		if (PlayerPrefs.GetInt ("Music", 1) == 1) {
			if (!ScenesManager.Instance.isRunGameScene) {
				for (int i = 0; i < arrMainMenuBgAudioSource.Count; i++) {
					arrMainMenuBgAudioSource [i].Play ();
				}
			} else {
				for (int i = 0; i < arrMainMenuBgAudioSource.Count; i++) {
					arrMainMenuBgAudioSource [i].Pause ();
				}
			}
		}
	}

	public void bgSoundOn ()
	{
		if (bgSound == null) {
			createBgSoundObject ();
			randomList ();
			return;
		}
		if (isBgSoundPause) {
			StartCoroutine (next ());
			arrGameBgAudioSource [index].Play ();
			isBgSoundPause = false;
			return;
		}
		if (arrGameBgAudioSource [index].isPlaying) {
			return;
		}

		arrGameBgAudioSource [index].Play ();
		StartCoroutine (next ());



	}

	void randomList ()
	{
		index = 0;
		List<AudioSource> tempSource = new List<AudioSource> ();
		for (int i = 0; i < arrGameBgAudioSource.Count; i++) {
			int tempIndex = Random.Range (0, arrGameBgAudioSource.Count);
			tempSource.Add (arrGameBgAudioSource [tempIndex]);
			arrGameBgAudioSource.RemoveAt (tempIndex);
			i--;
		}
		arrGameBgAudioSource = tempSource;
		bgSoundOn ();
	}

	IEnumerator next ()
	{
		yield return new WaitForSecondsRealtime (arrGameBgAudioSource [index].clip.length - arrGameBgAudioSource [index].time + 2);
		nextBgSound ();
	}

	void nextBgSound ()
	{
		arrGameBgAudioSource [index].Stop ();
		index++;
		if (index < arrGameBgAudioSource.Count) {
			bgSoundOn ();
		} else {
			randomList ();
		}
	}

	void bgSoundPlay ()
	{
		arrGameBgAudioSource [index].Play ();
	}


	public void bgSoundPause ()
	{
		StopAllCoroutines ();
		if (arrGameBgAudioSource.Count > 0) {
			arrGameBgAudioSource [index].Pause ();
			isBgSoundPause = true;
		}
	}

	void OnLevelWasLoaded ()
	{
		updatePlaying ();				
	}




}
