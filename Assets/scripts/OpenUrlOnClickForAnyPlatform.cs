using UnityEngine;
using System.Collections;

public class OpenUrlOnClickForAnyPlatform : MonoBehaviour {
	public string iOsUrl;
	public string androidUrl;

	// Use this for initialization
	void Start () {
	
	}

    void OnClick()
    {

        string currentUrl = androidUrl;

    #if UNITY_IPHONE
        currentUrl = iOsUrl;
    #endif

        Application.OpenURL(currentUrl);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
