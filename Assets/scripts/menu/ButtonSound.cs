using UnityEngine;
using System.Collections;

public class ButtonSound : MonoBehaviour
{

	void Start ()
	{
		if (PlayerPrefs.GetInt ("Sounds", 1) == 1) {
			gameObject.GetComponent<UIToggle> ().value = true;
			PlayerPrefs.SetInt ("Sounds", 1);
			AudioListener.volume = 1;
		} else if (PlayerPrefs.GetInt ("Sounds", 2) == 2) {
			gameObject.GetComponent<UIToggle> ().value = false;
			AudioListener.volume = 0;
		}
	}


	void OnClick ()
	{
		
		if (PlayerPrefs.GetInt ("Sounds", 2) == 2) {
			PlayerPrefs.SetInt ("Sounds", 1);
			AudioListener.volume = 1;
		} else if (PlayerPrefs.GetInt ("Sounds", 2) == 1) {
			PlayerPrefs.SetInt ("Sounds", 2);
			AudioListener.volume = 0;
		}
		
	}
}
