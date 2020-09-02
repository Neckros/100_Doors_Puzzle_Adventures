using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level006Object : MonoBehaviour
{
	public GameObject[] arrSwipeTopObj;
	public	GameObject collisedObj, previousColObj;
	Level006Controller controller;
	public GameObject collisionLine;
	public GameObject busyObj, emptyPoint;
	public bool isCollisedWithCollider, isStart = true, isSwipeTop, isSwipeBottom, isSwipeLeft, isSwipeRight;
	private Vector2 swipeStartPos;
	bool isSwiped;
	// Use this for initialization
	void Start ()
	{
		controller = GameObject.FindObjectOfType<Level006Controller> ().GetComponent<Level006Controller> ();
		isStart = true;
	}

	void OnTriggerEnter2D (Collider2D col)
	{	
		if (col.gameObject.name.Contains ("col")) {
			if (isStart) {
				gameObject.transform.position = new Vector3 (col.gameObject.transform.position.x, col.gameObject.transform.position.y, transform.position.z);
				isStart = false;
				previousColObj = col.gameObject;
				collisedObj = col.gameObject;
				col.gameObject.GetComponent<Level006Collider> ().isEmpty = false;
			} else {

				isCollisedWithCollider = true;
				collisedObj = col.gameObject;
			}

		}

	}

	void OnTouchDown (Vector2 pos)
	{
		swipeStartPos = pos;


	}

	void OnTouchUp ()
	{
		isSwiped = false;
	}

	void OnTouchDrag (Vector2 pos)
	{
		if (isSwiped) {
			return;
		}
		Vector2 swipeDiffPos = pos - swipeStartPos;
		float distance = Vector2.Distance (pos, swipeStartPos);
    

        if (distance > 20f)
        {
            if (Mathf.Abs(pos.x - swipeStartPos.x) > Mathf.Abs(pos.y - swipeStartPos.y))
            {
                if (pos.x > swipeStartPos.x)
                {
                    swipeRight();
                    isSwiped = true;
                }
                else
                {
                    swipeLeft();
                    isSwiped = true;
                }

            }
            else
            {
                if (pos.y > swipeStartPos.y)
                {
                    swipeTop();
                    isSwiped = true;

                }
                else
                {
                    swipeDown();
                    isSwiped = true;
                }

            }

        }
    }

	public void swipeTop ()
	{
		controller.bigCollider.SetActive (true);
		if (collisedObj != null)
			previousColObj = collisedObj;
		if (collisedObj.name == "col5") {

			gameObject.GetComponent<CircleCollider2D> ().offset = new Vector2 (0, 0.9f);

			isCollisedWithCollider = false;

			Invoke ("move", 0.12f);
		} else {
			controller.bigCollider.SetActive (false);
		}


//		Invoke ("move", 0.12f);

	}

	public void swipeDown ()
	{
		controller.bigCollider.SetActive (true);
		if (collisedObj != null)
			previousColObj = collisedObj;
		if (collisedObj.name == "col5") {

			gameObject.GetComponent<CircleCollider2D> ().offset = new Vector2 (0, -0.9f);
					
			isCollisedWithCollider = false;
		
			Invoke ("move", 0.12f);
		} else {
			controller.bigCollider.SetActive (false);
		}



		//	Invoke ("move", 0.12f);

	}

	public void swipeLeft ()
	{
		controller.bigCollider.SetActive (true);
		//		if (collisedObj != null)
		//			previousColObj = collisedObj;
		isCollisedWithCollider = false;
		isSwipeBottom = true;
		controller.objectCollider.transform.Find ("objCollider1").gameObject.GetComponent<Level006ObjectCollider> ().arrCollisedPoints.Clear ();
		controller.objectCollider.transform.position = gameObject.transform.position;
		controller.objectCollider.transform.Find ("objCollider1").gameObject.GetComponent<Level006ObjectCollider> ().parentObj = collisedObj;
		controller.objectCollider.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 180));
		controller.objectCollider.SetActive (true);


		Invoke ("move", 0.12f);
	}

	public void swipeRight ()
	{

		controller.bigCollider.SetActive (true);
		//		if (collisedObj != null)
		//			previousColObj = collisedObj;
		isCollisedWithCollider = false;
		isSwipeTop = true;
		controller.objectCollider.transform.Find ("objCollider1").gameObject.GetComponent<Level006ObjectCollider> ().arrCollisedPoints.Clear ();
		controller.objectCollider.transform.position = gameObject.transform.position;
		controller.objectCollider.transform.Find ("objCollider1").gameObject.transform.localPosition = Vector3.zero;
		controller.objectCollider.transform.Find ("objCollider1").gameObject.GetComponent<Level006ObjectCollider> ().parentObj = collisedObj;
		controller.objectCollider.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 0));
		controller.objectCollider.SetActive (true);

		Invoke ("move", 0.12f);
	}

	void move ()
	{
		if (isSwipeTop || isSwipeBottom) {
			isSwipeBottom = false;
			isSwipeTop = false;

			controller.objectCollider.SetActive (false);
			controller.bigCollider.SetActive (false);
			List<GameObject> arrPoint = controller.objectCollider.transform.Find ("objCollider1").gameObject.GetComponent<Level006ObjectCollider> ().arrCollisedPoints;
			if (arrPoint.Count == 0) {
				Invoke ("checkFinish", 0.25f);
				return;
			}
			if (arrPoint.Count > 1) {
				
				List<GameObject> arrBusyPoints = new List<GameObject> (); 
				for (int i = 0; i < arrPoint.Count; i++) {
					if (!arrPoint [i].GetComponent<Level006Collider> ().isEmpty) {
						arrBusyPoints.Add (arrPoint [i]);
					}
				}
				if (arrBusyPoints.Count > 0) {
					busyObj = arrBusyPoints [0];
					for (int i = 0; i < arrBusyPoints.Count; i++) {
						if (i + 1 < arrBusyPoints.Count) {
							if (Vector2.Distance (busyObj.transform.position, gameObject.transform.position) < Vector2.Distance (arrBusyPoints [i + 1].transform.position, gameObject.transform.position)) {
							} else {
								busyObj = arrBusyPoints [i + 1];
							}
						}
					}
				
					List<GameObject> arrEmptyPoints = new List<GameObject> (); 
					for (int i = 0; i < arrPoint.Count; i++) {
						if (Vector2.Distance (busyObj.transform.position, gameObject.transform.position) > Vector2.Distance (arrPoint [i].transform.position, gameObject.transform.position)) {
							arrEmptyPoints.Add (arrPoint [i]);
						}
					}
					if (arrEmptyPoints.Count == 0)
						return;
					emptyPoint = arrEmptyPoints [0];
					for (int i = 0; i < arrEmptyPoints.Count; i++) {
						if (i + 1 < arrEmptyPoints.Count) {
							if (Vector2.Distance (emptyPoint.transform.position, gameObject.transform.position) > Vector2.Distance (arrEmptyPoints [i + 1].transform.position, gameObject.transform.position)) {
							} else {
								emptyPoint = arrEmptyPoints [i + 1];
							}
						}
					}
				
					controller.swipeAudio.Play ();
					emptyPoint.GetComponent<Level006Collider> ().isEmpty = false;
					collisedObj.GetComponent<Level006Collider> ().isEmpty = true;
					TweenPosition.Begin (gameObject, 0.2f, new Vector3 (emptyPoint.transform.position.x, emptyPoint.transform.position.y, transform.position.z));
					Invoke ("checkFinish", 0.25f);
					return;
				} else {
					emptyPoint = arrPoint [0];
					for (int i = 0; i < arrPoint.Count; i++) {
						if (i + 1 < arrPoint.Count) {
							if (Vector2.Distance (emptyPoint.transform.position, gameObject.transform.position) > Vector2.Distance (arrPoint [i + 1].transform.position, gameObject.transform.position)) {
							} else {
								emptyPoint = arrPoint [i + 1];
							}
						}
					}
				}
				controller.swipeAudio.Play ();
				emptyPoint.GetComponent<Level006Collider> ().isEmpty = false;
				collisedObj.GetComponent<Level006Collider> ().isEmpty = true;
				TweenPosition.Begin (gameObject, 0.2f, new Vector3 (emptyPoint.transform.position.x, emptyPoint.transform.position.y, transform.position.z));
			} else {
				if (!arrPoint [0].GetComponent<Level006Collider> ().isEmpty)
					return;
				controller.swipeAudio.Play ();
				arrPoint [0].GetComponent<Level006Collider> ().isEmpty = false;
				collisedObj.GetComponent<Level006Collider> ().isEmpty = true;
				TweenPosition.Begin (gameObject, 0.2f, new Vector3 (arrPoint [0].transform.position.x, arrPoint [0].transform.position.y, transform.position.z));
			}
//			controller.objectCollider.SetActive (false);
		} else {
			if (isCollisedWithCollider) {
				if (collisedObj.GetComponent<Level006Collider> ().isEmpty) {
					controller.swipeAudio.Play ();
					TweenPosition.Begin (gameObject, 0.2f, new Vector3 (collisedObj.transform.position.x, collisedObj.transform.position.y, transform.position.z));
					collisedObj.GetComponent<Level006Collider> ().isEmpty = false;
					previousColObj.GetComponent<Level006Collider> ().isEmpty = true;
				}
			}
		}
		isCollisedWithCollider = false;
		gameObject.GetComponent<CircleCollider2D> ().offset = new Vector2 (0, 0);
		Invoke ("checkFinish", 0.25f);
	}

	void checkFinish ()
	{
		controller.checkFinish ();
	}


	// Update is called once per frame
	void Update ()
	{
		
	}
}
