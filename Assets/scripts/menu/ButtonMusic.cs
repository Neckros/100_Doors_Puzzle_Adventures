using UnityEngine;
using System.Collections;

public class ButtonMusic : MonoBehaviour
{

	void Start ()
	{
		if (PlayerPrefs.GetInt ("Music", 1) == 1) {
			GetComponent<UIToggle> ().value = true;
			PlayerPrefs.SetInt ("Music", 1);
			bgSoundOn ();
			return;
		} 
		if (PlayerPrefs.GetInt ("Music", 0) == 0) {
			GetComponent<UIToggle> ().value = false;
			bgSoundOff ();
		} 
	}

	void OnClick ()
	{
		if (PlayerPrefs.GetInt ("Music", 0) == 0) {
			PlayerPrefs.SetInt ("Music", 1);
			bgSoundOn ();
			return;
		} 
		if (PlayerPrefs.GetInt ("Music", 1) == 1) {
			PlayerPrefs.SetInt ("Music", 0);
			bgSoundOff ();

		}

	}

	public void bgSoundOff ()
	{
		AudioManager.Instance.bgSoundPause ();
	}

	public void bgSoundOn ()
	{

		AudioManager.Instance.bgSoundOn ();

	}
}
