using UnityEngine;
using System.Collections;
using System;

public class ExitGame : MonoBehaviour
{
		private int clickCount = 0;
		// Use this for initialization
		void Start ()
		{
				clickCount = 0;

		}

		void OnMouseUpAsButton ()
		{
				Application.Quit ();
		}

		void OnClick ()
		{
				showBanner ();
		}

		public void showBanner ()
		{
				try {
						Application.Quit ();
			
				} catch (Exception e) {
			
				}
		}

		// Update is called once per frame
		void Update ()
		{
				try {
						if (Input.GetKeyDown (KeyCode.Escape)) {
								showBanner ();
						}

				} catch (Exception e) {
						Debug.Log ("ExitGame.class Error");
				}
		}
}
