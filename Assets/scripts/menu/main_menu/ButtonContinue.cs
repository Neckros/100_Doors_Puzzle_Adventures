using UnityEngine;
using System.Collections;

public class ButtonContinue : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
			if (ProgressManager.Instance.getLevelState (1) == (int)ProgressManager.LevelState.state.Closed) {  // SELECT FIRST LEVEL AS AVAILABLE
				ProgressManager.Instance.setLevelState (1, ProgressManager.LevelState.state.Available);
			}
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnClick ()
		{
				int lastLevel = ProgressManager.Instance.getLastLevel ();
				
				if (lastLevel <= ScenesManager.getLevelsCount ()) {
						ScenesManager.Instance.changeScene (ScenesManager.Instance.getLevelById (lastLevel));
				} else {
						for (int i=1; i<=ScenesManager.getLevelsCount(); i++) {
								if (ProgressManager.Instance.getLevelState (i) == 1) {
										ScenesManager.Instance.changeScene (ScenesManager.Instance.getLevelById (i));
										return;
								}
										
						}
						ScenesManager.Instance.changeScene (ScenesManager.Instance.getLevelById (lastLevel - 1));			
				}
		}

}
