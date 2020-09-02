using UnityEngine;
using System.Collections;

public class CameraAspect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		for(int i=0; i<Camera.allCamerasCount; i++){
			Camera.allCameras[i].aspect=480f / 800f;	
		}
	}
}
