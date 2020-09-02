using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventListener : MonoBehaviour {
	[HideInInspector]
	public List<EventDelegate>
		events = new List<EventDelegate>();
	[HideInInspector]
	public bool
		clearAfterExecuting;
	
	protected void executeEvents() {
		EventDelegate.Execute(events);	

		if (clearAfterExecuting)
			events.Clear();
	}
}
