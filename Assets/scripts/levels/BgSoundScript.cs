using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSoundScript : MonoBehaviour
{
	void Awake ()
	{
		if (AudioManager.Instance.bgSound == null)
			DontDestroyOnLoad (gameObject);
	}
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
