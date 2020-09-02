using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level008Controlller : MonoBehaviour
{
	public GameObject paperBig, paperLittle, curtain, cloth, nitWithIgl, dress1, dress2, maneken;
	public AudioSource magicAudio, clickAudio;
	bool isPaperScaled, isNitToInventory, isIglaToInventory;
	// Use this for initialization
	void Start ()
	{
		
	}

	public void showPaper ()
	{
		paperLittle.SetActive (false);
		paperBig.SetActive (true);
		isPaperScaled = true;
		clickAudio.Play ();
	}

	public void scalePaper ()
	{
		if (!isPaperScaled) {
			
			TweenPosition.Begin (paperBig, 0.2f, new Vector3 (0, 1, paperBig.transform.position.z));
			TweenScale.Begin (paperBig, 0.2f, new Vector3 (1f, 1f, 1));
			isPaperScaled = true;
			clickAudio.Play ();
		}
	}

	public void closePaper ()
	{
		if (isPaperScaled) {
			isPaperScaled = false;
			TweenScale.Begin (paperBig, 0.2f, new Vector3 (0.3f, 0.3f, 1));
			TweenPosition.Begin (paperBig, 0.2f, new Vector3 (-1.2f, 2.55f, paperBig.transform.position.z));
			clickAudio.Play ();
		}
	}

	public void scissorsToCurtain ()
	{
		curtain.SetActive (false);
		cloth.SetActive (true);
		cloth.GetComponent<Entity> ().PickUp ();
	}

	public void ojectsToInventory (GameObject obj)
	{
		if (obj.name == "Igl")
			isIglaToInventory = true;
		else
			isNitToInventory = true;

		if (isNitToInventory && isIglaToInventory) {
			Invoke ("removeObjFromInventory", 0.7f);
		}
	}


	private void removeObjFromInventory ()
	{
		for (int i = 0; i < GameObject.FindObjectOfType<Inventory> ().getEntity.Length; i++) {
			if (GameObject.FindObjectOfType<Inventory> ().getEntity [i].GetComponent<InventorySlot> ().get () != null && GameObject.FindObjectOfType<Inventory> ().getEntity [i].GetComponent<InventorySlot> ().get ().name == "Igl") {
				GameObject.FindObjectOfType<Inventory> ().getEntity [i].GetComponent<InventorySlot> ().remove ();
			}
			if (GameObject.FindObjectOfType<Inventory> ().getEntity [i].GetComponent<InventorySlot> ().get () != null && GameObject.FindObjectOfType<Inventory> ().getEntity [i].GetComponent<InventorySlot> ().get ().name == "Nit02") {
				GameObject.FindObjectOfType<Inventory> ().getEntity [i].GetComponent<InventorySlot> ().remove ();
			}
		}
		nitWithIgl.SetActive (true);
		nitWithIgl.GetComponent<Entity> ().PickUp ();
		magicAudio.Play ();
	}

	public void showDress1 ()
	{
		if (paperBig.activeSelf) {
			dress1.SetActive (true);
			GameObject.FindObjectOfType<Inventory> ().removeActiveEntity ();
		}
	}

	public void showDress2 ()
	{
		if (dress1.activeSelf) {
			dress2.SetActive (true);
			dress1.SetActive (false);
			GameObject.FindObjectOfType<Inventory> ().removeActiveEntity ();
			magicAudio.Play ();
			Invoke ("openDoor", 1);

		}
	}

	public void openDoor ()
	{
		TweenPosition.Begin (maneken, 0.3f, new Vector3 (2, maneken.transform.position.y, maneken.transform.position.z));
		gameObject.GetComponent<AudioSource> ().Play ();
		GameObject.Find ("Exit").GetComponent<Exit> ().openDelayed_1 ();
	}
	// Update is called once per frame
	void Update ()
	{
		
	}
}
