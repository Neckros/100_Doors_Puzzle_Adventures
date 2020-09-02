using UnityEngine;
using System.Collections;

public class ProgressManager : MonoBehaviour
{
	public static class LevelState
	{
		public enum state : int
		{
			Closed = 0,
			Available = 1,
			Opened = 2}

		;
		
	}

	private static ProgressManager instance;

	public static ProgressManager Instance {
		get {
			if (instance == null) {
				GameObject container = new GameObject ("ProgressManager");
				instance = container.AddComponent<ProgressManager> ();
			}
			return instance;
		}

	}

	public void setLevelState (int levelId, LevelState.state state)
	{
		string prefKey = "level" + ExtraManager.Instance.getLevelId (levelId) + ".state";
		PlayerPrefs.SetInt (prefKey, (int)state);
		print ("level " + ExtraManager.Instance.getLevelId (levelId) + " has been opened" + state);
	
	}

	public void setLastLevel (int levelId)
	{
		string LastLevel = "LastLevel";
		PlayerPrefs.SetInt (LastLevel, levelId);
		//print("level " + ExtraManager.Instance.getLevelId(levelId) + " has been opened" + state);
		
	}

	public bool loadLevel (int levelId)
	{
		return ScenesManager.Instance.changeScene (ScenesManager.Instance.getLevelById (levelId));
	}

	public int getLevelState (int levelNumber)
	{
		if (PlayerPrefs.GetInt ("level" + ExtraManager.Instance.getLevelId (levelNumber) + ".state") == (int)LevelState.state.Available) {
			return (int)LevelState.state.Available;
		}
		if (PlayerPrefs.GetInt ("level" + ExtraManager.Instance.getLevelId (levelNumber) + ".state") == (int)LevelState.state.Opened) {
			return (int)LevelState.state.Opened;
		}

		return (int)LevelState.state.Closed;
	}

	public int getLastLevel ()
	{
		string LastLevel = "LastLevel";
		int lastLevel = PlayerPrefs.GetInt (LastLevel, 0);
		if (lastLevel < 1) {
			lastLevel = 1;		
		}
		return lastLevel;
		//print("level " + ExtraManager.Instance.getLevelId(levelId) + " has been opened" + state);
		
	}

	public bool StageIsOpen (int stageNumber)
	{
		if (PlayerPrefs.GetInt ("Stage" + stageNumber + "isOpen") == 1) {
			return true;
		}
		if (stageNumber == 1) {
			return true;
		}
		return false;
	}



}
