using UnityEngine;
using System.Collections;
using System;

public class ScenesManager : MonoBehaviour
{
	private static ScenesManager instance;
	private GameObject mainWrapperObject;
	//private MainWrapperScript mainWrapper;
	private float closeDuration;
	private static string[] levelAssociation = {
		"Level003" //1  винтаж
		, "Level005" //2  винтаж
		, "Level074" //3  винтаж2
		, "Level048" //4  библиотека
		, "Level090" //5  гараж2
		, "Level050" //6  сад2
		, "Level020" //7  винтаж
		, "Level044" //8  сад                
		, "Level037" //9  библиотека
		, "Level012" //10 винтаж
		, "Level058" //11 библиотека2
		, "Level086" //12 сад
		, "Level089" //13 гараж 
		, "Level004" //14 винтаж
		, "Level045" //15 сад
		, "Level001" //16 гараж2
		, "Level047" //17 библиотека2
		, "Level075" //18 винтаж2
		, "Level065" //19 сад
		, "Level097" //20 библиотека2
		, "Level088" //21 гараж2
		, "Level064" //22 библиотека2
		, "Level019" //23 винтаж2
		, "Level027" //24 сад
		, "Level087" //25 гараж
		, "Level080" //26 библиотека
		, "Level055" //27 винтаж  
		, "Level083" //28 сад2
		, "Level076" //29 гараж
		, "Level062" //30 библиотека2
		//----------------30 ----------------
		, "Level015" //31 винтаж
		, "Level094" //32 сад2
		, "Level092" //33 гараж
		, "Level038" //34 библиотека
		, "Level024" //35 винтаж
		, "Level029" //36 сад
		, "Level079" //37 гараж
		, "Level057" //38 библиотека
		, "Level063" //39 винтаж  
		, "Level040" //40 сад
//		//----------------40 ----------------
		, "Level085" //41 гараж
		, "Level036" //42 библиотека2
		, "Level073" //43 винтаж
		, "Level054" //44 сад
		, "Level096" //45 гараж2
		, "Level082" //46 библиотека
		, "Level013" //47 винтаж2
		, "Level068" //48 сад
		, "Level100" //49 гараж
		, "Level051" //50 библиотека
//		//----------------50 ----------------
		, "Level011" //51 винтаж
		, "Level043" //52 сад
		, "Level077" //53 гараж
		, "Level016" //54 винтаж
		, "Level018" //55 винтаж2
		, "Level023" //56 сад
		, "Level071" //57 гараж
		, "Level052" //58 библиотека
		, "Level002" //59 винтаж
		, "Level066" //60 сад
//		//----------------60 ----------------
		, "Level091"  //61 гараж
		, "Level009"  //62 библиотека
		, "Level069"  //63 винтаж
		, "Level067"  //64 сад
		, "Level026"  //65 гараж
		, "Level039"  //66 библиотека2
		, "Level070"  //67 винтаж2
		, "Level078"  //68 сад
		, "Level022"  //69 гараж
		, "Level025"  //70 библиотека2
//		//----------------70 ----------------
		, "Level017"  //71 винтаж2
		, "Level030"  //72 сад
		, "Level084"  //73 гараж
		, "Level042"  //74 библиотека2
		, "Level010"  //75 винтаж2
		, "Level031"  //76 сад
		, "Level093"  //77 гараж
		, "Level041"  //78 библиотека2
		, "Level021"  //79 винтаж2
		, "Level008"  //80 винтаж
//		//----------------80 ----------------
		, "Level028"  //81 сад
	        , "Level033"  //82 гараж
		, "Level061"  //83 библиотека2
		, "Level014"  //84 винтаж
		, "Level060"  //85 сад
		, "Level095"  //86 гараж
		, "Level099"  //87 библиотека
		, "Level034"  //88 винтаж2
		, "Level056"  //89 сад
		, "Level032"  //90 гараж
//		//----------------90 ----------------
		, "Level053"  //91 библиотека
		, "Level035"  //92 винтаж2
		, "Level059"  //93 сад
		, "Level072"  //94 гараж 
		, "Level102"  //95 библиотека
		, "Level081"  //96 винтаж2
		, "Level046"  //97 сад
		, "Level007"  //98 гараж 
		, "Level006"  //99 библиотека2   
		, "Level098"  //100 винтаж


	};

	public static ScenesManager Instance {
		get {
			if (instance == null) {
				GameObject container = new GameObject ("ScenesManager");
				instance = container.AddComponent<ScenesManager> ();
				DontDestroyOnLoad (instance);  
			}
			return instance;
		}
	}

	void Awake ()
	{

				
	}

	public bool changeScene (string targetSceneName)
	{
		showAds (targetSceneName);
				
		Input.multiTouchEnabled = true;
		if (Application.CanStreamedLevelBeLoaded (targetSceneName)) {
			Application.LoadLevel (targetSceneName);
			//AudioManager.Instance.bgSoundPause ();
			return true;
		} else {
			Application.LoadLevel ("Level003");
			return false;
		}
		return true;
	
	}

	IEnumerator waitForOpen (string targetSceneName)
	{
		yield return new WaitForSeconds (closeDuration);  
		Application.LoadLevel (targetSceneName);
	}

	public string getLevelById (int id)
	{
		try {
			return levelAssociation [id - 1];
		} catch (Exception e) {
			return "MenuLevels";		
		}
	}

	public static int getIdByLevelName (string levelName)
	{
		try {
			for (int i = 0; i <= levelAssociation.Length; i++) {
				if (levelAssociation [i].Equals (levelName)) {
					return i + 1;
				}
			}
		} catch (Exception e) {
				
		}
		return 1;
	}

	public bool isGameScene (string sceneName)
	{
		return sceneName.StartsWith ("Level");
	}

	public bool isRunGameScene {
		get {
			return isGameScene (Application.loadedLevelName);
		}
	}

	public static int getLevelsCount ()
	{
		return levelAssociation.Length;
	}

	private void showAds (string targetSceneName)
	{
		try {
			
			if (getIdByLevelName (targetSceneName) % 3 == 0) {
				if (AdsManager.Instance.isInterstitialRedy ()) {
					AdsManager.Instance.showInterstitialAds ();
				} else {
					AdsManager.Instance.loadInterstitial ();
				}
									
			} else {
				if (!AdsManager.Instance.isInterstitialRedy ()) {
					AdsManager.Instance.loadInterstitial ();
				} else {
						
				}
					
			}
								
		} catch (Exception e) {
			Debug.Log ("Error ScenesManager.class, showAds");		
		}

	}
}