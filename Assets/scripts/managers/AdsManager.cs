using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;

//using GoogleMobileAds.Api;
using System.Net;


public class AdsManager : MonoBehaviour
{
	private static AdsManager instance;
	private static bool testMode = false;
	private float maxAdsShowTime = 15;
	private float lastAdsShow;
#if UNITY_IPHONE
    private static string bannerId = "ca-app-pub-3442742958156221/3499510470";
    private static string interstitialId = "ca-app-pub-3442742958156221/5271579531";
    private static string appId = "ca-app-pub-3531953422373006~2164884440";
#else
    private static string bannerId = "ca-app-pub-3531953422373006/5510492264";
	private static string interstitialId = "ca-app-pub-3531953422373006/9160046941";
    private static string appId = "ca-app-pub-3531953422373006~2164884440";
#endif

    BannerView bannerView;
	InterstitialAd interstitial;

    private void Awake()
    {
        MobileAds.Initialize(appId);
    }

    void Start ()
	{
		lastAdsShow = maxAdsShowTime;
		try {

			bannerView = new BannerView (bannerId, AdSize.SmartBanner, AdPosition.Bottom);
			AdRequest request = new AdRequest.Builder ().Build ();
			bannerView.LoadAd (request);

			interstitial = new InterstitialAd (interstitialId);


		} catch (Exception e) {
			Debug.Log ("AdsManager line 28-32 Error");
		}
	}

	void Update ()
	{
		if (lastAdsShow < maxAdsShowTime) {		
			lastAdsShow += Time.deltaTime;
		}
	}

	public static AdsManager Instance {
		get {
			if (instance == null) {
				GameObject container = new GameObject ("_AdsManager");
				instance = container.AddComponent<AdsManager> ();
				DontDestroyOnLoad (instance); 
				if (Application.platform == RuntimePlatform.Android) {

                		
		
				}
			}
			return instance;
		}
	}

	public void showAdmobAds ()
	{
		//if (Const.isDesktop)
		//return;
		try {
			bannerView.Show ();

		} catch (Exception e) {
			
		}
	}

	public void hideAdmobAds ()
	{
		//if (Const.isDesktop)
		//	return;
		try {
			bannerView.Hide ();
		} catch (Exception e) {
				
		}
	}

	public void loadInterstitial ()
	{
		try {
			if (!isInterstitialRedy ()) {
				AdRequest request = new AdRequest.Builder ().Build ();
				interstitial.LoadAd (request);

			}
		} catch (Exception e) {
		}
	}

	public void showInterstitialAds ()
	{
		try {
			if (lastAdsShow >= maxAdsShowTime) {
				if (interstitial.IsLoaded ()) {
					interstitial.Show ();
				}
				lastAdsShow = 0;
			}
		} catch (Exception e) {
				
		}
	}

	public bool isInterstitialRedy ()
	{
		return interstitial.IsLoaded ();
		;

	}
}
