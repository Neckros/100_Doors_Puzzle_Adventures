using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(InventoryListener))]
public class InventoryListenerEditor : EventListenerEditor {
	public override void OnInspectorGUI() {
		InventoryListener script = (InventoryListener) target;
		script.isTouch = EditorGUILayout.Toggle("Is Touch", script.isTouch);
		script.requiredItem = EditorGUILayout.ObjectField("Required Item", script.requiredItem, typeof(Entity), true) as Entity;
	
		EditorGUI.BeginDisabledGroup(!script.requiredItem);
		script.removeAfterUsage = EditorGUILayout.Toggle("Remove After Usage", script.removeAfterUsage);

		EditorGUI.BeginDisabledGroup(script.removeAfterUsage);
		script.playInventorySound = EditorGUILayout.Toggle("Play Inventory Sound", script.playInventorySound);
		EditorGUI.EndDisabledGroup();


		DrawEvents();		
		EditorGUI.EndDisabledGroup();
	}
}
