using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(TargetTransform))]
public class TargetTransformEditor : Editor {
	public override void OnInspectorGUI() {
		TargetTransform script = (TargetTransform) target;

		script.parentTransform = (Transform) EditorGUILayout.ObjectField("Parent Transform", script.parentTransform, typeof(Transform));
		
		script.isPosition = EditorGUILayout.ToggleLeft("Position", script.isPosition);
		if (script.isPosition)
			script.position = EditorGUILayout.Vector3Field("", script.position);

		script.isRotation = EditorGUILayout.ToggleLeft("Rotation", script.isRotation);
		if (script.isRotation)
			script.rotation = EditorGUILayout.Vector3Field("", script.rotation);

		script.isScale = EditorGUILayout.ToggleLeft("Scale", script.isScale);
		if (script.isScale)
			script.scale = EditorGUILayout.Vector3Field("", script.scale);

	}
}
