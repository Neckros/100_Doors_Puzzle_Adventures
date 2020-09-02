using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelSelectMenuButtons : MonoBehaviour
{
	public Stage stage1, stage2;
	private Stage activeStage;
	private bool buttonsActive;
	private float deltaTime = 0.3f;
	public AudioSource audioClick;
	private float STAGE_DISTANCE;
	public GameObject buttonLeft, buttonRight;
	public GameObject[] arrLinks;

	void Start ()
	{
		activeStage = stage1;
		buttonsActive = true;
		stage1.setStageNumber (GameManager.Instance.getCurrentStage ());
		STAGE_DISTANCE = stage2.transform.localPosition.x - stage1.transform.localPosition.x;

		if (GameManager.Instance.getCurrentStage () == 0) {
			buttonLeft.SetActive (false);
		}
		if (GameManager.Instance.getCurrentStage () == GameManager.Instance.getStageCount () - 1) {
			buttonRight.SetActive (false);
		}
		//randomLink ();
	}

	void Awake ()
	{

	}

	public void randomLink ()
	{
		for (int i = 0; i < arrLinks.Length; i++) {
			arrLinks [i].SetActive (false);
		}
		arrLinks [Random.Range (0, arrLinks.Length)].SetActive (true);
		Invoke ("randomLink", 10);
	}


	public void BackToMenuButton ()
	{
		//SoundManager.Instance.audioClickPlay ();
		//GameManager.Instance.GoTooMainMenuScene ();
	}

	public void activateButtons ()
	{
		buttonsActive = true;
	}


	public void LeftButtonClick ()
	{
		if (buttonsActive) {
			if (GameManager.Instance.getCurrentStage () == 0) {
				return;
			}
			if (GameManager.Instance.getCurrentStage () == 1) {
				buttonLeft.SetActive (false);
			}
			buttonRight.SetActive (true);
			buttonsActive = false;
			Invoke ("activateButtons", deltaTime);
			GameManager.Instance.stagePrevious ();
			if (activeStage == stage1) {
				stage2.transform.localPosition = new Vector3 (-STAGE_DISTANCE, stage2.transform.localPosition.y, stage2.transform.localPosition.z);
				stage2.setStageNumber (GameManager.Instance.getCurrentStage ());
				activeStage = stage2;
			} else {
				stage1.transform.localPosition = new Vector3 (-STAGE_DISTANCE, stage1.transform.localPosition.y, stage1.transform.localPosition.z);
				stage1.setStageNumber (GameManager.Instance.getCurrentStage ());
				activeStage = stage1;
			}
			TweenPosition.Begin (stage1.gameObject, deltaTime, (stage1.transform.localPosition + new Vector3 (STAGE_DISTANCE, 0, 0)));
			TweenPosition.Begin (stage2.gameObject, deltaTime, stage2.transform.localPosition + new Vector3 (STAGE_DISTANCE, 0, 0));
		}
	}

	public void RightButtonClick ()
	{
		if (buttonsActive) {
			if (GameManager.Instance.getCurrentStage () == GameManager.Instance.getStageCount () - 1) {
				return;
			}
			if (GameManager.Instance.getCurrentStage () == GameManager.Instance.getStageCount () - 2) {
				buttonRight.SetActive (false);
			}
			buttonLeft.SetActive (true);
			buttonsActive = false;
			Invoke ("activateButtons", deltaTime);
			GameManager.Instance.stageNext ();
			if (activeStage == stage1) {
				stage2.transform.localPosition = new Vector3 (STAGE_DISTANCE, stage2.transform.localPosition.y, stage2.transform.localPosition.z);
				stage2.setStageNumber (GameManager.Instance.getCurrentStage ());
				activeStage = stage2;
			} else {
				stage1.transform.localPosition = new Vector3 (STAGE_DISTANCE, stage1.transform.localPosition.y, stage1.transform.localPosition.z);
				stage1.setStageNumber (GameManager.Instance.getCurrentStage ());
				activeStage = stage1;
			}
			TweenPosition.Begin (stage1.gameObject, deltaTime, (stage1.transform.localPosition - new Vector3 (STAGE_DISTANCE, 0, 0)));
			TweenPosition.Begin (stage2.gameObject, deltaTime, stage2.transform.localPosition - new Vector3 (STAGE_DISTANCE, 0, 0));
		}
		
	}

	public void settingsButtonClick ()
	{
		//GameManager.Instance.GoTooSettingsScene ();
	}
}
