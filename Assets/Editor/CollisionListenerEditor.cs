using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CollisionListener))]
public class CollisionListenerEditor : EventListenerEditor {
	public override void OnInspectorGUI() {
		CollisionListener script = (CollisionListener) target;
		bool isWarning = !script.GetComponent<Rigidbody2D>() && !(script.targetObject && script.targetObject.GetComponent<Rigidbody2D>());
		if (isWarning) {
			string warningText = "One of the components must have a Rigidbody2D \n\n For disable physics: \n   - GravityScale = 0 \n   - IsTrigger = true.";
			EditorGUILayout.HelpBox(warningText, MessageType.Warning);
		}

		base.OnInspectorGUI();
	}
}