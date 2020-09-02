using UnityEngine;
using System.Collections;

public class ExitEvents : MonoBehaviour {
	public Exit exit;

	public void open() {
		exit.open();
	}

	public void touchableEnable() {
		exit.touchableEnable();
	}
	
	public void touchableDisable() {
		exit.touchableDisable();
	}

}
