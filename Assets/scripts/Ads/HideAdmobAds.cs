using UnityEngine;
using System.Collections;

public class HideAdmobAds : MonoBehaviour {
	// Use this for initialization
	void Start () {
		AdsManager.Instance.hideAdmobAds ();
	}
	void FixedUpdate () {
		AdsManager.Instance.hideAdmobAds ();
	}
}
