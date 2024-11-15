using System;

public interface IAdsFacade
{
    void ShowInterstitialAds();
    void ShowRewardedAds(Action rewardCallback);
}