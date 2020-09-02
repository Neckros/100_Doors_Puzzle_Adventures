using UnityEngine;
using System.Collections;

public class OpenScene : MonoBehaviour {
	public string scene_name;
	void OnClick() {
				ScenesManager.Instance.changeScene (scene_name);
		}
}
