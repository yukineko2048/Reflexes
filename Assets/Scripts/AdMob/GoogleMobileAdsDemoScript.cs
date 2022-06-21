using System;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class GoogleMobileAdsDemoScript : SingletonMonoBehaviour<GoogleMobileAdsDemoScript>
{
    private BannerView bannerView;

    private RewardedAd rewardedAd;
    public void AdStart()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        string adUnitId;
        #if UNITY_ANDROID
            adUnitId = "ca-app-pub-3940256099942544/5224354917"; //テストID
        #elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313"; //テストID
        #else
            adUnitId = "unexpected_platform";
        #endif
        this.rewardedAd = new RewardedAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);

        this.RequestBanner();
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: " + args.LoadAdError);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: " + args.AdError);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
             "HandleRewardedAdRewarded event received for "
                 + amount.ToString() + " " + type);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
        
        CoinManager.Instance.AddCoin((int)amount);
        TitleManager.Instance.CoinUpdate();
    }

    private void RequestBanner()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/6300978111"; //テストID
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716"; //テストID
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom
        );

        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerView.OnAdClosed += this.HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        // this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;
        // 使えなくなってるのでコメントアウト

        // 広告の読み込みが完了してから処理を行う
        this.bannerView.OnAdLoaded += HandleRewardBasedVideoLoaded;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
        this.bannerView.Show();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message");
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    //=================================
    //リワード広告が読み込まれたら実行
    //=================================
    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        this.bannerView.Show();
    }

    public void UserChoseToWatchAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
        else{
            MonoBehaviour.print("まだ広告が読み込まれていません");
        }
    }

    // public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    // {
    //     MonoBehaviour.print("HandleAdLeavingApplication event received");
    // }
}