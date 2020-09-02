using UnityEngine;
using System.Collections;

public class ExtraManager : MonoBehaviour {
	private static ExtraManager instance;
	public static readonly bool isDesktop = Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor;
	
	public static ExtraManager Instance {
		get {
			if (instance == null) {
				GameObject container = new GameObject("ExtraManager");
				instance = container.AddComponent<ExtraManager>();
			}
			return instance;
		}
	}

	public string getLevelId(int levelId) {
		string levelIdString;
		levelIdString = levelId < 10 ? "00" : "0";
		if(levelId>99){
			levelIdString = "";
		}
		levelIdString += levelId;
		return levelIdString;

	}

	public GameObject hit(Vector2 screenPos) {
		return hit(screenPos, true);
	}
	
	public GameObject hit(Vector2 pos, bool isScreenPos) {
		if (!isScreenPos) {		// ScreenPos this is - from 0x0 to 480x800 (example).
			pos = Camera.main.WorldToScreenPoint(pos);			
		}

		Ray ray = Camera.main.ScreenPointToRay(pos); 
		RaycastHit2D raycastHit2D = Physics2D.GetRayIntersection(ray);
		if (raycastHit2D.collider)
			return raycastHit2D.collider.gameObject;
		else
			return null;
	}

	public GameObject hitThroughObject(Vector2 screenPos, GameObject throughObject) {
		return hitThroughObject(screenPos, throughObject, true);
	}
	
	public GameObject hitThroughObject(Vector2 pos, GameObject throughObject, bool isScreenPos) {
		bool curColliderActivity = throughObject.GetComponent<Collider2D>().enabled;
		throughObject.GetComponent<Collider2D>().enabled = false;
		GameObject hitObject = hit(pos, isScreenPos);
		throughObject.GetComponent<Collider2D>().enabled = curColliderActivity;
		return hitObject;
	}

	public GameObject[] getChildren(Transform transform) {
		int n = transform.childCount;
		GameObject[] children = new GameObject[n];
		for (int i = 0; i < n; i++) {
			children[i] = transform.GetChild(i).gameObject;
		}
		return children;
	}
}
