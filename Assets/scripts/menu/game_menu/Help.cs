using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
	public GameObject pauseMenu, blackPoint;
	public bool isMenuShowing;

	void Start ()
	{
	}


	public void OnClick ()
	{
		StopAllCoroutines ();
		if (pauseMenu.GetComponent<Settings> ().isMenuShowing) {
			pauseMenu.GetComponent<Settings> ().StopAllCoroutines ();
			pauseMenu.GetComponent<Settings> ().hideMenu ();
			StartCoroutine (showMenu ());
		} else {
			showHideMenu ();
		}
		pauseMenu.GetComponent<BoxCollider> ().enabled = false;
		GetComponent<BoxCollider> ().enabled = false;



	}

	public void hideMenu ()
	{
		Time.timeScale = 1;
		GameObject.Find ("help_menu").GetComponent<Animator> ().SetTrigger ("show_menu");
		GameObject.Find ("title_bg").GetComponent<Animator> ().SetTrigger ("show_menu");
		TweenColor.Begin (blackPoint, 0f, new Color32 (255, 255, 255, 0));
		blackPoint.SetActive (false);
		isMenuShowing = false;
	}

	public void showHideMenu ()
	{

		GameObject.Find ("clickAudio").GetComponent<AudioSource> ().Play ();

		GameObject.Find ("help_menu").GetComponent<Animator> ().SetTrigger ("show_menu");
		GameObject.Find ("title_bg").GetComponent<Animator> ().SetTrigger ("show_menu");
		TweenColor.Begin (blackPoint, 0f, new Color32 (255, 255, 255, 0));
		blackPoint.SetActive (false);
		isMenuShowing = !isMenuShowing;
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
			StartCoroutine (activateButtons ());
		} else {
			StartCoroutine (showBlackBg ());
			StartCoroutine (pauseGame ());
			StartCoroutine (activateButtons ());
		}
	}

	IEnumerator showMenu ()
	{
		yield return new WaitForSecondsRealtime (0.5f);
		showHideMenu ();
	}

	IEnumerator showBlackBg ()
	{
		yield return new WaitForSecondsRealtime (0.3f);
		showBg ();
	}

	void showBg ()
	{
		blackPoint.SetActive (true);
		TweenColor.Begin (blackPoint, 0.1f, new Color32 (255, 255, 255, 190));
	}

	IEnumerator activateButtons ()
	{
		yield return new WaitForSecondsRealtime (0.6f);
		activateButton ();
	}

	IEnumerator pauseGame ()
	{
		yield return new WaitForSecondsRealtime (0.5f);
		onGamePause ();
	}

	private void onGamePause ()
	{
		Time.timeScale = 0;
	}

	private void activateButton ()
	{
		pauseMenu.GetComponent<BoxCollider> ().enabled = true;
		GetComponent<BoxCollider> ().enabled = true;
	}
}

