using UnityEngine;
using System.Collections;

public class ScriptingHelp : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}

	void Awake ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTouchDown (Vector2 pos)
	{

	}

	void OnTouchUp ()
	{
	}

	void OnTouchDrag (Vector2 pos)
	{
	}

	void OnTriggerEnter2D (Collider2D col)
	{	
		if (col.gameObject.name == "name_obj") {

		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.gameObject.name == "name_obj") {

		}
	}

	void OnTriggerStay2D (Collider2D coll)
	{
		//print ("Collision Stay "+ coll.gameObject.name);
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Enemy")
			coll.gameObject.SendMessage ("ApplyDamage", 10);
		
	}

	public void moveObjectByAccelerometer ()
	{ // put too void FixedUpdate ()
		float speed = 10;

		float moveHorizontal; 
		float moveVertical; 
		
		
		moveHorizontal = Input.acceleration.x; 
		moveVertical = Input.acceleration.y; 
		
		
		
		gameObject.GetComponent<Rigidbody2D> ().gravityScale = -moveVertical;
		gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (moveHorizontal * speed, 0));
	}


	private float AngleBetweenVector2 (Vector2 vec1, Vector2 vec2) //ROTATE GAMEOBJECT TO ANGLE FROM TWO VECTORS
	{
		Vector2 diference = vec2 - vec1;
		float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
		return Vector2.Angle (Vector2.right, diference) * sign;
	}

	public void openDoor ()
	{
//		doorlock.SetActive (false);
		gameObject.GetComponent<AudioSource> ().Play ();
		GameObject.Find ("Exit").GetComponent<Exit> ().openDelayed_1 ();
	}

	public void restartLevel ()
	{
		GameObject.FindObjectOfType<RestartLevel> ().GetComponent<RestartLevel> ().restartLevel ();
	}


}
