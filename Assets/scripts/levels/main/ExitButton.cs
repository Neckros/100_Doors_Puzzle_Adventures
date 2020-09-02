using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour
{
	public Exit exit;

	private void OnTouchClick ()
	{
		int levelId = exit.getLevelId ();
		bool isNextLevelLoaded = ProgressManager.Instance.loadLevel (levelId + 1);

		if (!isNextLevelLoaded) {
			ScenesManager.Instance.changeScene ("MainMenu");
			AudioManager.Instance.bgSoundPause ();
		}
	}
}