using UnityEngine;
using System.Collections;

public class KeyboardEngine : MonoBehaviour {
	public string password;
	public MonoBehaviour solutionListener;
	public int maxLenght = 9;
	public string solution;
	public TextMesh label;
	public AudioSource soundError, soundSuccess;
	public GameObject keyboardButton;
	public GameObject keyboardPlate;

	void Awake() {
		label.text = solution;
	}

	public bool push(string value) {
		if (value == "reset") {
			reset();
			return true;
		} else if (value == "enter") {
			checkSolution();
			return true;
		} else {
			if (solution.Length < maxLenght) {
				addToSolution(value);
				return true;
			}
		}
		return false;
	}

	private void addToSolution(string value) {
		solution += value;
		label.text = solution;
	}

	public void reset() {
		solution = "";
		label.text = solution;
	}
	
	private bool checkSolution() {
		if (solution == password) {
			success();
			return true;
		} else {
			soundError.Play();
			reset();
			return false;
		}
	}

	void success() {
		print("Keyboard: Success!");
		keyboardButton.SetActive(false);
		GetComponent<Animator>().SetTrigger("success");
		if (solutionListener)
			solutionListener.SendMessage("OnKeyboardSuccess", SendMessageOptions.DontRequireReceiver);
		else
			gameObject.SendMessage("OnKeyboardSuccess", SendMessageOptions.DontRequireReceiver);
	}
	
	public void show() {
		GetComponent<Animator>().SetTrigger("show");
		soundSuccess.Play();
	}
	
	public void hide() {
		GetComponent<Animator>().SetTrigger("hide");
		soundSuccess.Play();
	}
}
