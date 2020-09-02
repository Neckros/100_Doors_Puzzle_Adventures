using UnityEngine;
using System.Collections;

public class MainMenuButton : MonoBehaviour
{

	GameObject menu_bg;
	// Use this for initialization
	void Start ()
	{
		menu_bg = GameObject.Find ("main_menu");
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnClick ()
	{
		//	 (menu_bg.transform.localPosition.y > 0) {
		if (Time.timeScale == 0)
			Time.timeScale = 1;
		
		GameObject.Find ("PauseMenu").GetComponent<Settings> ().hideMenu ();
		Invoke ("openMenu", 0.5f);
		GameObject.Find ("clickAudio").GetComponent<AudioSource> ().Play ();

	}

	private void openMenu ()
	{
		AudioManager.Instance.bgSoundPause ();
		ScenesManager.Instance.changeScene ("MainMenu");

	}
}
