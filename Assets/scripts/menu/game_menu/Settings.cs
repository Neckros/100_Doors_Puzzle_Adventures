using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour
{

	public GameObject helpMenu, blackPoint;
	// Use this for initialization


	public bool isMenuShowing;

	void Start ()
	{
	}


	public void OnClick ()
	{
		StopAllCoroutines ();
		if (helpMenu.GetComponent<Help> ().isMenuShowing) {
			helpMenu.GetComponent<Help> ().hideMenu ();
			helpMenu.GetComponent<Help> ().StopAllCoroutines ();
//			Invoke ("showHideMenu", 0.5f);

			StartCoroutine (showMenu ());
		} else {
			showHideMenu ();
		}
		helpMenu.GetComponent<BoxCollider> ().enabled = false;
		GetComponent<BoxCollider> ().enabled = false;

	}

	public void hideMenu ()
	{
		Time.timeScale = 1;
		GameObject.Find ("main_menu").GetComponent<Animator> ().SetTrigger ("show_menu");
		GameObject.Find ("title_bg").GetComponent<Animator> ().SetTrigger ("show_menu");
		isMenuShowing = false;
		TweenColor.Begin (blackPoint, 0f, new Color32 (255, 255, 255, 0));
		blackPoint.SetActive (false);
	}



	public void showHideMenu ()
	{
//		if (buttonActive) {
		GameObject.Find ("clickAudio").GetComponent<AudioSource> ().Play ();
		GameObject.Find ("main_menu").GetComponent<Animator> ().SetTrigger ("show_menu");
		GameObject.Find ("title_bg").GetComponent<Animator> ().SetTrigger ("show_menu");
		isMenuShowing = !isMenuShowing;
		TweenColor.Begin (blackPoint, 0f, new Color32 (255, 255, 255, 0));
		blackPoint.SetActive (false);

		if (Time.timeScale == 0) {
			Time.timeScale = 1;
			StartCoroutine (activateButtons ());
		} else {
			StartCoroutine (pauseGame ());
			StartCoroutine (activateButtons ());
			StartCoroutine (showBlackBg ());
		}
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

	IEnumerator showMenu ()
	{
		yield return new WaitForSecondsRealtime (0.5f);
		showHideMenu ();
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
		helpMenu.GetComponent<BoxCollider> ().enabled = true;
		GetComponent<BoxCollider> ().enabled = true;

	}
}
