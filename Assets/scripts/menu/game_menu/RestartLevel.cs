using UnityEngine;
using System.Collections;

public class RestartLevel : MonoBehaviour
{
	Exit entry;
	// Use this for initialization
	void Start ()
	{
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
		GameObject.Find ("clickAudio").GetComponent<AudioSource> ().Play ();
		Invoke ("restartLevel", 0.5f);
	}

	public void restartLevel ()
	{

		int levelId = entry.getLevelId ();
		
		bool isNextLevelLoaded = ProgressManager.Instance.loadLevel (levelId);

		if (!isNextLevelLoaded) {			
			ScenesManager.Instance.changeScene ("MainMenu");
		}
	}
}
