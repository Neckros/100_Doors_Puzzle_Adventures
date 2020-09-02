using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	private static GameManager inst;
	private static readonly string containerName = "_GameManager";
	private string CURRENT_STAGE = "CurrentStage";
	private const int stageCount = 4;

	public static GameManager Instance { 
		get {
			if (!inst) {
				spawn ();
			} 
			return inst;
		}
	}

	private static void spawn ()
	{
		GameObject container = new GameObject (containerName);
		DontDestroyOnLoad (container);
		inst = container.AddComponent<GameManager> ();
		inst.init ();		
	}

	private void init ()
	{
		AudioManager audioManager = AudioManager.Instance;
		ScenesManager scenesManager = ScenesManager.Instance;
		audioManager.updatePlaying ();
	}

	void Start ()
	{
		if (!inst || gameObject.name != containerName) {
			GameManager temp = Instance;
			Destroy (this);
			return;
		} 
	}

	void OnApplicationQuit ()
	{

	}

	public void enable ()
	{
		MonoBehaviour[] components = gameObject.GetComponents<MonoBehaviour> ();
		foreach (var component in components) {
			component.enabled = true;
		}
	}

	public void disable ()
	{
		MonoBehaviour[] components = gameObject.GetComponents<MonoBehaviour> ();
		foreach (var component in components) {
			component.enabled = false;
		}
	}


	public int getStageCount ()
	{
		return stageCount;
	}

	public int getCurrentStage ()
	{
		return PlayerPrefs.GetInt (CURRENT_STAGE, 0);
	}

	public void setCurrentStage (int stageNumber)
	{
		PlayerPrefs.SetInt (CURRENT_STAGE, stageNumber);
	}

	public void stageNext ()
	{
		if (PlayerPrefs.GetInt (CURRENT_STAGE, 0) < stageCount) {
			PlayerPrefs.SetInt (CURRENT_STAGE, PlayerPrefs.GetInt (CURRENT_STAGE, 0) + 1);
		} else {
			PlayerPrefs.SetInt (CURRENT_STAGE, 0);
		}
	}

	public void stagePrevious ()
	{
		if (PlayerPrefs.GetInt (CURRENT_STAGE, 0) > 0) {
			PlayerPrefs.SetInt (CURRENT_STAGE, PlayerPrefs.GetInt (CURRENT_STAGE, 0) - 1);
		} else {
			PlayerPrefs.SetInt (CURRENT_STAGE, stageCount);
		}
	}





	// ----- Don't use this methods!
	void OnDestroy ()
	{
	}

	void OnEnable ()
	{
			
	}

	void OnDisable ()
	{
	}
	// ----- end.
}
