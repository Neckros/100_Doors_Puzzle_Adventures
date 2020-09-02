using UnityEngine;
using System.Collections;

public class LevelButton : MonoBehaviour
{
	
	public UILabel LevelNumberLabel;
	public GameObject Closed;
	public GameObject Opened;
	public GameObject Available;
	public float rotationSpeed = 1f;
	public GameObject wait_updates;
	int currentNumber = 0;
	//	public GameObject Lock;


	// Use this for initialization
	void Start ()
	{
		//UpdateButtonState ();
	}

	public void setLevelNumber (int iLevelNumber)
	{
		currentNumber = iLevelNumber;
		UpdateButtonState ();

	}

	public void resetButtonNameState (int stage, int indexNumber)
	{
		currentNumber = (stage * 25) + indexNumber + 1;
		UpdateButtonState ();

	}

	private void UpdateButtonState ()
	{
		
		LevelNumberLabel.text = "" + int.Parse (ExtraManager.Instance.getLevelId (currentNumber));
		if (currentNumber == 1) {
			if (ProgressManager.Instance.getLevelState (currentNumber) == (int)ProgressManager.LevelState.state.Closed) {
				ProgressManager.Instance.setLevelState (currentNumber, ProgressManager.LevelState.state.Available);
			}
		}
		
		if (ProgressManager.Instance.getLevelState (currentNumber) == (int)ProgressManager.LevelState.state.Available) {
			Available.GetComponent<UISprite> ().enabled = false;
			Opened.GetComponent<UISprite> ().enabled = false;
			Closed.GetComponent<UISprite> ().enabled = false;
			Closed.GetComponent<Animator> ().enabled = false;
			LevelNumberLabel.enabled = true;
			wait_updates.GetComponent<UILabel> ().enabled = false;
		}
		if (ProgressManager.Instance.getLevelState (currentNumber) == (int)ProgressManager.LevelState.state.Opened) {
			Available.GetComponent<UISprite> ().enabled = false;
			Opened.GetComponent<UISprite> ().enabled = true;
			Closed.GetComponent<UISprite> ().enabled = false;
			Closed.GetComponent<Animator> ().enabled = false;
			LevelNumberLabel.enabled = true;
			wait_updates.GetComponent<UILabel> ().enabled = false;
		}
		if (ProgressManager.Instance.getLevelState (currentNumber) == (int)ProgressManager.LevelState.state.Closed) {
			Available.GetComponent<UISprite> ().enabled = false;
			Opened.GetComponent<UISprite> ().enabled = false;
			Closed.GetComponent<UISprite> ().enabled = true;
			LevelNumberLabel.enabled = true;
			wait_updates.GetComponent<UILabel> ().enabled = false;
		}
		
		if (ScenesManager.getLevelsCount () < currentNumber) {
			Available.GetComponent<UISprite> ().enabled = true;
			Opened.GetComponent<UISprite> ().enabled = false;
			Closed.GetComponent<UISprite> ().enabled = false;
			Closed.GetComponent<Animator> ().enabled = false;
			LevelNumberLabel.enabled = false;
			wait_updates.GetComponent<UILabel> ().enabled = true;
			
		}
		

	}

	void OnClick ()
	{
		if (ProgressManager.Instance.getLevelState (currentNumber) != (int)ProgressManager.LevelState.state.Closed && (ScenesManager.getLevelsCount () >= currentNumber)) {
			ProgressManager.Instance.loadLevel (currentNumber);
			ProgressManager.Instance.setLastLevel (currentNumber);
		}

	}

	void Update ()
	{



	}
}
