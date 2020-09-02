using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivaciPolicyButton : MonoBehaviour {
		private GameObject privacyPolicyPanel, main_buttons, level_menu_buttons;
		private Vector3 levelsMenuStartPosition;

		// Use this for initialization
		void Start () {
				privacyPolicyPanel = GameObject.Find ("Privaci_polici_panel");	
				main_buttons = GameObject.Find ("main_buttons");
				level_menu_buttons = GameObject.Find ("LevelListPanel");
				levelsMenuStartPosition = level_menu_buttons.transform.localPosition;

		}

		void OnClick()
		{
				TweenPosition.Begin (level_menu_buttons, 0.2f, levelsMenuStartPosition);
				TweenPosition.Begin (main_buttons, 0.2f, new Vector3(-500, 0, 0));
				TweenPosition.Begin (privacyPolicyPanel, 0.2f, new Vector3(0, 0, 0));
		}
}