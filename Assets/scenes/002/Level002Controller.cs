using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level002Controller : MonoBehaviour
{
	public GameObject[] arrLines;
	public GameObject container, previosMovedLine, screenCollider, blur;
	public	bool isContainerMoved;
	public AudioSource magicAudio, errorAudio, coinAudio;
	public Sprite sprGreen, sprRed;
	public float speed = 1.5f;
	public UILabel label;
	public int clickCount = 0;
	public bool youwin;
	public int cellClickCount = 40;

	// Use this for initialization
	void Start ()
	{
		label.text = "" + clickCount + "/" + cellClickCount;
	}

	public void gameOver ()
	{
		errorAudio.Play ();
		isContainerMoved = false;
//		screenCollider.GetComponent<BoxCollider2D> ().enabled = true;
		for (int i = 0; i < arrLines.Length; i++) {
			arrLines [i].GetComponent<Level002Line> ().transform.localPosition = arrLines [i].GetComponent<Level002Line> ().startPos;
			arrLines [i].GetComponent<Level002Line> ().restartLine ();
			if (arrLines [i].name != "line1")
				arrLines [i].transform.Find ("collider").gameObject.SetActive (true);
			else
				arrLines [i].transform.Find ("collider").gameObject.SetActive (false);

			if (arrLines [i].name == "line8") {
				previosMovedLine = arrLines [i];
//				arrLines [i].GetComponent<Level002Line> ().topLine = arrLines [i];
			} 
//			else
//				arrLines [i].GetComponent<Level002Line> ().topLine = arrLines [i + 1];
		}
		container.transform.position = new Vector3 (0, 1,	container.transform.position.z);
		clickCount = 0;
		speed = 1.5f;
		label.text = "" + clickCount + "/" + cellClickCount;
	}

	public void  clickToContainer ()
	{
//		screenCollider.GetComponent<BoxCollider2D> ().enabled = false;
		isContainerMoved = true;
	}

	public void checkFinish ()
	{
		if (clickCount == cellClickCount) {
			isContainerMoved = false;
			youwin = true;
			magicAudio.Play ();
			Invoke ("hideMiniGame", 1);
		}
	}

	void hideMiniGame ()
	{
//		TweenPosition.Begin (gameObject, 1, new Vector3 (5, gameObject.transform.position.y, gameObject.transform.position.z));
		for (int i = 0; i < arrLines.Length; i++) {
			for (int j = 0; j < arrLines [i].transform.childCount; j++) {
				if (arrLines [i].transform.GetChild (j).gameObject.GetComponent<SpriteRenderer> () != null) {
					TweenColor.Begin (arrLines [i].transform.GetChild (j).gameObject, 0.5f, new Color (1, 1, 1, 0));
					arrLines [i].transform.GetChild (j).gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				}
			}

		}
		TweenColor.Begin (blur, 0.5f, new Color (1, 1, 1, 0));
		Invoke ("openDoor", 1);
		label.text = "";
	}

	public void openDoor ()
	{
		gameObject.GetComponent<AudioSource> ().Play ();
		GameObject.Find ("Exit").GetComponent<Exit> ().openDelayed_1 ();
	}
	// Update is called once per frame
	void Update ()
	{
		if (isContainerMoved) {
			container.transform.position = new Vector3 (container.transform.position.x, container.transform.position.y - speed * Time.deltaTime, container.transform.position.z);
		}
		
	}
}
