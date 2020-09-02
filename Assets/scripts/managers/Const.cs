using UnityEngine;
using System.Collections;

public class Const : MonoBehaviour
{
	public static readonly bool isDesktop = 
		Application.platform == RuntimePlatform.WindowsEditor ||
		Application.platform == RuntimePlatform.OSXEditor ||
		Application.platform == RuntimePlatform.WindowsPlayer ||
//		Application.platform == RuntimePlatform.WindowsWebPlayer ||
		Application.platform == RuntimePlatform.OSXPlayer;
	//		||  Application.platform == RuntimePlatform.OSXDashboardPlayer;


}
