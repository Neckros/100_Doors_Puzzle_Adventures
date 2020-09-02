using UnityEngine;
using System.Collections;

public class ToolboxMenu : MonoBehaviour {
	GameObject panel;
	bool isOpen = false;
	TweenPosition Open, Close;
	public UILabel DOOR_title;

	// Use this for initialization
	void Start () {
		GameObject o = GameObject.Find("Exit");
		Exit entry = o.GetComponent<Exit>();
		int levelId = entry.getLevelId();



		if (levelId < 10) {
			DOOR_title.text = "DOOR 0" + levelId;		
				} else {
			DOOR_title.text = "DOOR " + levelId;	
		}



		panel = GameObject.Find ("main_menu");

		Open = panel.AddComponent<TweenPosition> ();
		Open.from = new Vector3 (0,790,0);
		Open.to = new Vector3 (0, 240,0);
		Open.duration = 0.3f;


		Close = panel.AddComponent<TweenPosition> ();
		Close.from = new Vector3 (0,240,0);
		Close.to = new Vector3 (0, 790,0);
		Close.duration = 0.3f;

		panel.transform.Translate (new Vector3 (0, -216, 0));
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick ()
	{
		Debug.Log ("OnClick");
		changeStateMenu ();
	}

	public void changeStateMenu(){
				if (isOpen) {
						isOpen = false;
						Close.Play (true);
						Open.Play(false);
				} else {
					isOpen=true;
					Open.Play (true);
					Close.Play (false);
				}
		}
}
