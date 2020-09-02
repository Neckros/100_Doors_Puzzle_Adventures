using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour
{
	private int levelId;
	public bool isTouchToOpen;
	public string requiredObjectToOpen;
	public GameObject door;
	public GameObject arrow;
	public GameObject exitButton;
	public GameObject exitBackground;
	public AudioSource soundBeep;
	public AudioSource soundOpen;
	private bool isOpened;

	void Awake ()
	{
		IsTouchToOpen = isTouchToOpen;
		levelId = ScenesManager.getIdByLevelName (Application.loadedLevelName);
		ProgressManager.Instance.setLastLevel (levelId);
		System.GC.Collect ();
	}

	void OnTouchClick ()
	{
		if (requiredObjectToOpen.Equals ("")) {
			open ();
		}
	}

	void OnInventoryClick (Entity entity)
	{
		if (requiredObjectToOpen.Equals (entity.name)) {
			entity.removeFromInventory ();
			open ();
		}
	}

	public bool IsTouchToOpen {
		get {
			return this.isTouchToOpen;
		}
		set {
			isTouchToOpen = value;
			GetComponent<Collider2D> ().enabled = value;		
		}
	}

	public void open ()
	{
		if (isOpened)
			return;
		isOpened = true;
		door.GetComponent<Animator> ().SetTrigger ("open");
		arrow.SetActive (true);
		exitButton.SetActive (true);
//		soundBeep.Play ();
		soundOpen.Play ();
		exitBackground.SetActive (true);
		if (ProgressManager.Instance.getLevelState (levelId) != (int)ProgressManager.LevelState.state.Opened) {
			ProgressManager.Instance.setLevelState (levelId, ProgressManager.LevelState.state.Opened);
			if (ProgressManager.Instance.getLevelState (levelId + 1) != (int)ProgressManager.LevelState.state.Opened) {
				ProgressManager.Instance.setLevelState (levelId + 1, ProgressManager.LevelState.state.Available);
				ProgressManager.Instance.setLastLevel (levelId + 1);
			}
		}
	}

	public void openDelayed_05 ()
	{
		openDelayed (0.5f);
	}

	public void openDelayed_1 ()
	{
		openDelayed (1f);
	}

	public void openDelayed_2 ()
	{
		openDelayed (2f);
	}

	public void openDelayed (float delay)
	{
		Invoke ("open", delay);
	}

	public void touchableEnable ()
	{
		IsTouchToOpen = true;
	}

	public void touchableDisable ()
	{
		IsTouchToOpen = false;
	}

	public int getLevelId ()
	{
		return levelId;
	}
}
