using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EventListener), true)]
public class EventListenerEditor : Editor {

	public override void OnInspectorGUI() {
		DrawDefaultInspector();
		DrawEvents();
	}

	public void DrawEvents() {
		EventListener script = (EventListener) target;
		if (NGUIEditorTools.DrawHeader("Events")) {
			NGUIEditorTools.BeginContents();
			script.clearAfterExecuting = EditorGUILayout.ToggleLeft(" Clear After Executing", script.clearAfterExecuting);
			EditorGUILayout.Space();
			EventDelegateEditor.Field(script.gameObject, script.events);
			NGUIEditorTools.EndContents();
		}
	}
}
