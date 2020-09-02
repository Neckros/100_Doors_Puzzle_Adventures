using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level009Cell : MonoBehaviour
{


	public Color startColor;
	// Use this for initialization
	void Start ()
	{
		startColor = GetComponent<SpriteRenderer> ().color;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
