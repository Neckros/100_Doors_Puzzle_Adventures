using UnityEngine;
using System.Collections;

public class HideAdsBanner : MonoBehaviour
{
		public GameObject hidenObject;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

	void OnClick() {
				hidenObject.SetActive (false);	
		}
}
