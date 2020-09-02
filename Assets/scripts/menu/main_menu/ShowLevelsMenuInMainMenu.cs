using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLevelsMenuInMainMenu : MonoBehaviour {

		private GameObject privacyPolicyPanel, main_buttons, level_menu_buttons;
		private Vector3 privacyPolicyStartPosition;

		// Use this for initialization
		void Start () {
				privacyPolicyPanel = GameObject.Find ("Privaci_polici_panel");	
				main_buttons = GameObject.Find ("main_buttons");
				level_menu_buttons = GameObject.Find ("LevelListPanel");
				privacyPolicyStartPosition = privacyPolicyPanel.transform.localPosition;
		}

		void OnClick()
		{
				TweenPosition.Begin (privacyPolicyPanel, 0.2f, privacyPolicyStartPosition);
				TweenPosition.Begin (main_buttons, 0.2f, new Vector3(-500,0, 0));
				TweenPosition.Begin (level_menu_buttons, 0.2f, new Vector3(-0,0, 0));
		}
}
		