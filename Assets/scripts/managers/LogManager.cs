using UnityEngine;
using System.Collections;

public class LogManager : MonoBehaviour {
	private static LogManager instance;

	public static LogManager Instance {
		get {
			if (instance == null) {
				GameObject container = new GameObject("LogManager");
				instance = container.AddComponent<LogManager>();
			}
			return instance;
		}
	}

	public void Log(string text) {
		print(text);
	}
}
