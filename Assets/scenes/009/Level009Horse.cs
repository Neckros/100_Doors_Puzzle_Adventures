using UnityEngine;
using System.Collections;

public class Level009Horse : MonoBehaviour
{
	public Level009CollisionDetector colDetector;
	private Level009Controller controller;
	private Vector3 lastPosition, newPosition;
	private int stroka, stolbec;
	bool isCollisionWithFinish;


	// Use this for initialization
	void Start ()
	{
		controller = GameObject.FindObjectOfType<Level009Controller> ().GetComponent<Level009Controller> ();

	}

	void OnTouchDown (Vector2 pos)
	{
//		setHorseCollider (false);
		lastPosition = gameObject.transform.position;
		stroka = int.Parse (colDetector.getLastCollideObject ().name.Substring (4, 1));
		stolbec = int.Parse (colDetector.getLastCollideObject ().name.Substring (5, 1));
		gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 10;
		availableMoves ();
		GetComponent<AudioSource> ().Play ();
//		setHorseCollider (false);
		controller.horse.GetComponent<BoxCollider2D> ().enabled = true;
	}

	//	private void setHorseCollider (bool enable)
	//	{
	//		for (int i = 0; i < controller.arrHorse.Length; i++) {
	//			if (!controller.arrHorse [i].Equals (this.gameObject)) {
	//				if (enable) {
	//					controller.arrHorse [i].GetComponent<PolygonCollider2D> ().enabled = true;
	//				} else {
	//					controller.arrHorse [i].GetComponent<PolygonCollider2D> ().enabled = false;
	//				}
	//			}
	//		}
	//	}

	void OnTouchUp ()
	{
		
		for (int i = 0; i < controller.cells.Length; i++) {
			TweenColor.Begin (controller.cells [i], 0.1f, controller.cells [i].GetComponent<Level009Cell> ().startColor);

		}
		if (isHasNewPosition ()) {
			TweenPosition.Begin (gameObject, 0f, new Vector3 (newPosition.x, newPosition.y, gameObject.transform.position.z));
			lastPosition = colDetector.getLastCollideObject ().transform.position;
			gameObject.GetComponent<SpriteRenderer> ().sortingOrder = int.Parse (colDetector.getLastCollideObject ().name.Substring (4, 1));
			gameObject.GetComponent<AudioSource> ().Play ();
			Invoke ("checkFinish", 0.4f);
		} else {
			TweenPosition.Begin (gameObject, 0.1f, new Vector3 (lastPosition.x, lastPosition.y, gameObject.transform.position.z));
			gameObject.GetComponent<SpriteRenderer> ().sortingOrder = stroka;
		}
//		setHorseCollider (true);
		controller.horse.GetComponent<BoxCollider2D> ().enabled = true;
	}

	private void checkFinish ()
	{
		if (isCollisionWithFinish) {
			controller.openLittleDoor ();
			TweenScale.Begin (gameObject, 0.2f, Vector3.zero);
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{	
		if (col.gameObject.name == "finish") {
			isCollisionWithFinish = true;
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.gameObject.name == "finish") {
			isCollisionWithFinish = false;
		}
	}

	private bool isHasNewPosition ()
	{
		if (int.Parse (colDetector.getLastCollideObject ().name.Substring (4, 1)) == ((stroka - 2)) && int.Parse (colDetector.getLastCollideObject ().name.Substring (5, 1)) == ((stolbec + 1))) {
			newPosition = colDetector.getLastCollideObject ().transform.position;
			return true;
		}
		if (int.Parse (colDetector.getLastCollideObject ().name.Substring (4, 1)) == ((stroka - 2)) && int.Parse (colDetector.getLastCollideObject ().name.Substring (5, 1)) == ((stolbec - 1))) {
			newPosition = colDetector.getLastCollideObject ().transform.position;
			return true;
		}
		if (int.Parse (colDetector.getLastCollideObject ().name.Substring (4, 1)) == ((stroka - 1)) && int.Parse (colDetector.getLastCollideObject ().name.Substring (5, 1)) == ((stolbec + 2))) {
			newPosition = colDetector.getLastCollideObject ().transform.position;
			return true;
		}
		if (int.Parse (colDetector.getLastCollideObject ().name.Substring (4, 1)) == ((stroka + 1)) && int.Parse (colDetector.getLastCollideObject ().name.Substring (5, 1)) == ((stolbec + 2))) {
			newPosition = colDetector.getLastCollideObject ().transform.position;
			return true;
		}
		if (int.Parse (colDetector.getLastCollideObject ().name.Substring (4, 1)) == ((stroka + 2)) && int.Parse (colDetector.getLastCollideObject ().name.Substring (5, 1)) == ((stolbec + 1))) {
			newPosition = colDetector.getLastCollideObject ().transform.position;
			return true;
		}
		if (int.Parse (colDetector.getLastCollideObject ().name.Substring (4, 1)) == ((stroka + 2)) && int.Parse (colDetector.getLastCollideObject ().name.Substring (5, 1)) == ((stolbec - 1))) {
			newPosition = colDetector.getLastCollideObject ().transform.position;
			return true;
		}
		if (int.Parse (colDetector.getLastCollideObject ().name.Substring (4, 1)) == ((stroka - 1)) && int.Parse (colDetector.getLastCollideObject ().name.Substring (5, 1)) == ((stolbec - 2))) {
			newPosition = colDetector.getLastCollideObject ().transform.position;
			return true;
		}
		if (int.Parse (colDetector.getLastCollideObject ().name.Substring (4, 1)) == ((stroka + 1)) && int.Parse (colDetector.getLastCollideObject ().name.Substring (5, 1)) == ((stolbec - 2))) {
			newPosition = colDetector.getLastCollideObject ().transform.position;
			return true;
		}

		return false;
	
	}

	private void availableMoves ()
	{
		for (int i = 0; i < controller.cells.Length; i++) {
	
			if (int.Parse (controller.cells [i].name.Substring (4, 1)) == ((stroka - 2)) && int.Parse (controller.cells [i].name.Substring (5, 1)) == ((stolbec + 1))) {
				newCellColor ((stroka - 2), (stolbec + 1));
			}
			if (int.Parse (controller.cells [i].name.Substring (4, 1)) == ((stroka - 2)) && int.Parse (controller.cells [i].name.Substring (5, 1)) == ((stolbec - 1))) {
				newCellColor ((stroka - 2), (stolbec - 1));
			}
			if (int.Parse (controller.cells [i].name.Substring (4, 1)) == ((stroka - 1)) && int.Parse (controller.cells [i].name.Substring (5, 1)) == ((stolbec + 2))) {
				newCellColor ((stroka - 1), (stolbec + 2));
			}
			if (int.Parse (controller.cells [i].name.Substring (4, 1)) == ((stroka + 1)) && int.Parse (controller.cells [i].name.Substring (5, 1)) == ((stolbec + 2))) {
				newCellColor ((stroka + 1), (stolbec + 2));
			}
			if (int.Parse (controller.cells [i].name.Substring (4, 1)) == ((stroka + 2)) && int.Parse (controller.cells [i].name.Substring (5, 1)) == ((stolbec + 1))) {
				newCellColor ((stroka + 2), (stolbec + 1));
			}
			if (int.Parse (controller.cells [i].name.Substring (4, 1)) == ((stroka + 2)) && int.Parse (controller.cells [i].name.Substring (5, 1)) == ((stolbec - 1))) {
				newCellColor ((stroka + 2), (stolbec - 1));
			}
			if (int.Parse (controller.cells [i].name.Substring (4, 1)) == ((stroka - 1)) && int.Parse (controller.cells [i].name.Substring (5, 1)) == ((stolbec - 2))) {
				newCellColor ((stroka - 1), (stolbec - 2));
			}
			if (int.Parse (controller.cells [i].name.Substring (4, 1)) == ((stroka + 1)) && int.Parse (controller.cells [i].name.Substring (5, 1)) == ((stolbec - 2))) {
				newCellColor ((stroka + 1), (stolbec - 2));
			}

		}
	}

	private void newCellColor (int stroka, int stolbec)
	{
		for (int i = 0; i < controller.cells.Length; i++) {
			
			if (int.Parse (controller.cells [i].name.Substring (4, 1)) == stroka && int.Parse (controller.cells [i].name.Substring (5, 1)) == stolbec) {
				TweenColor.Begin (controller.cells [i], 0.2f, Color.green);
				break;
			}
		}
	}

	//	private bool isCellEmpty (float x, float y)
	//	{
	//		for (int i = 0; i < controller.arrHorse.Length; i++) {
	//			if (controller.arrHorse [i].transform.position.x == x && controller.arrHorse [i].transform.position.y == y) {
	//				return true;
	//				break;
	//			}
	//		}
	//		return false;
	//	}



	// Update is called once per frame
	void Update ()
	{
	
	}
}
