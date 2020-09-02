using UnityEngine;
using System.Collections;

public class LetterLevel100 : MonoBehaviour
{
	public GameObject letterEn, letterRu;
	private bool isShowed;

	// Use this for initialization
	void Start ()
	{
		isShowed = false;
		if (Application.systemLanguage == SystemLanguage.Russian || Application.systemLanguage == SystemLanguage.Ukrainian || Application.systemLanguage == SystemLanguage.Belarusian) {
			letterEn.SetActive (false);
			letterRu.SetActive (true);
		} else {
			letterEn.SetActive (true);
			letterRu.SetActive (false);
		}
	
		//Invoke ("showLetter", 1f);
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void hideLetter ()
	{
		TweenRotation.Begin (gameObject, 0.5f, Quaternion.Euler (new Vector3 (1, 1, 180)));
		TweenScale.Begin (gameObject, 0.5f, new Vector3 (0, 0, 0));
		Invoke ("disableObject", 1f);
		gameObject.GetComponent<AudioSource> ().Play ();

	}

	private void disableObject ()
	{
		gameObject.SetActive (false);
	}

	public void showLetter ()
	{
		if (!isShowed) {
			isShowed = true;
			TweenRotation.Begin (gameObject, 0.5f, Quaternion.Euler (new Vector3 (0, 0, 0)));
			TweenScale.Begin (gameObject, 0.5f, new Vector3 (1, 1, 1));
			gameObject.GetComponent<AudioSource> ().Play ();
		} else {
			ScenesManager.Instance.changeScene ("MainMenu");
		}
	}

	public void doorIsOpeneed ()
	{
	
		showLetter ();
	}
}
