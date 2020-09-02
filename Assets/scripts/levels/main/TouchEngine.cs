using UnityEngine;
using System.Collections.Generic;

public class TouchEngine : MonoBehaviour
{
	public bool isForced;
	private string forcedTag = "Forced";
	//private RuntimePlatform platform;
	private bool isDesktop;
	private GameObject hitObjectDesctop;
	private Vector2 prevPosDesktop;
	private Dictionary<int,GameObject> hits;
    public Camera mainCamera;

	public ParticleSystem particle;

	void Awake ()
	{
		//platform = Application.platform;
		isDesktop = ExtraManager.isDesktop;
		hits = new Dictionary<int, GameObject> ();
        if (mainCamera == null)
            mainCamera = Camera.main;

	}

	private Touch prevTouch;

	void Update ()
	{
		if (isDesktop)
			updateDesktop ();
		else
			updateMobile ();
	}

	private void updateDesktop ()
	{
		string phase = getMouseHitPhase ();
		if (phase != null) {
			Vector2 pos = Input.mousePosition;
			if (isForced) {
				GameObject hitObject = checkTouch (pos);
				if (hitObject) {
					hit (hitObject, phase + forcedTag, pos);					
				}
			}

			if (phase.Equals ("OnTouchDown")) {
				hitObjectDesctop = checkTouch (pos);

				Vector2 localPos = mainCamera.ScreenToWorldPoint (pos); 
				particle.transform.position = new Vector3 (localPos.x, localPos.y, particle.transform.position.z);
				particle.GetComponent<ParticleSystem> ().loop = true;
				particle.Play ();
			}
			if (hitObjectDesctop) {
				if (phase.Equals ("OnTouchDrag") && pos == prevPosDesktop) { 
					return;
				}
				prevPosDesktop = pos;
				Vector2 localPos = mainCamera.ScreenToWorldPoint (pos); 
				particle.transform.position = new Vector3 (localPos.x, localPos.y, particle.transform.position.z);
				hit (hitObjectDesctop, phase, pos);	

				if (phase.Equals ("OnTouchUp")) {			
					particle.GetComponent<ParticleSystem> ().loop = false;
					if (hitObjectDesctop.Equals (checkTouch (pos))) {
						hit (hitObjectDesctop, "OnTouchClick", pos);
					}													
					hitObjectDesctop = null;
				}
			}
		}
	}

	private void updateMobile ()
	{
		if (Input.touchCount > 0) {
			foreach (var touch in Input.touches) {
				string phase = getHitPhase (touch);	

				if (isForced) {
					GameObject hitObject = checkTouch (touch.position);
					if (hitObject) {
						hit (hitObject, phase + forcedTag, touch.position);					
					}
				}

				if (phase.Equals ("OnTouchDown")) {
					GameObject hitObject = checkTouch (touch.position);
					if (hitObject) {
						hits.Add (touch.fingerId, hitObject);
					}
					Vector2 localPos = mainCamera.ScreenToWorldPoint (touch.position); 
					particle.transform.position = new Vector3 (localPos.x, localPos.y, particle.transform.position.z);
					particle.GetComponent<ParticleSystem> ().loop = true;
					particle.Play ();
				}
				if (phase.Equals ("OnTouchDrag")) { 
					particle.transform.position = new Vector3 (mainCamera.ScreenToWorldPoint (touch.position).x, mainCamera.ScreenToWorldPoint (touch.position).y, particle.transform.position.z);
				}
				if (hits.Count > 0) {
					if (hits.ContainsKey (touch.fingerId)) {
						GameObject hitObject = hits [touch.fingerId];

						hit (hitObject, phase, touch.position);

						bool isTouchFinish = phase.Equals ("OnTouchUp");							
						if (isTouchFinish) {
							particle.GetComponent<ParticleSystem> ().loop = false;
							if (hitObject.Equals (checkTouch (touch.position))) {
								hit (hitObject, "OnTouchClick", touch.position);
							}								
							hits.Remove (touch.fingerId);
						}
					}

				}
			}
		} 
	}

	private GameObject checkTouch (Vector2 pos)
	{
		Ray ray = mainCamera.ScreenPointToRay (pos); 
		RaycastHit2D raycastHit2D = Physics2D.GetRayIntersection (ray);
		if (raycastHit2D.collider) {
			return raycastHit2D.collider.gameObject;
		}
		return null;
	}

	private string getMouseHitPhase ()
	{		
		if (Input.GetMouseButtonDown (0)) {
			return "OnTouchDown";
		} else if (Input.GetMouseButton (0)) {
			return "OnTouchDrag";	
		} else if (Input.GetMouseButtonUp (0)) {
			return "OnTouchUp";
		}
		return null;
	}

	private string getHitPhase (Touch touch)
	{
		string touchType = "OnTouch";
		switch (touch.phase) {
		case TouchPhase.Began:
			touchType += "Down";
			break;
		case TouchPhase.Moved:
			touchType += "Drag";
			break;
		case TouchPhase.Canceled:
		case TouchPhase.Ended:
			touchType += "Up";
			break;
		}
		return touchType;
	}

	private void hit (GameObject hitObject, string hitPhase, Vector2 pos)
	{

		//		print(hitPhase + " | " + hitObject.name);
		sendMessage (hitObject, hitPhase, pos);
	}

	private void sendMessage (GameObject gameObject, string methodName, object value)
	{
		gameObject.SendMessage (methodName, value, SendMessageOptions.DontRequireReceiver);

	}
}
