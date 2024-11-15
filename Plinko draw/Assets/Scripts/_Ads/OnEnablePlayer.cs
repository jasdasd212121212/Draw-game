using UnityEngine;
using Zenject;

public class OnEnablePlayer : MonoBehaviour
{
    [Inject] private IAdsFacade _ads;

    private void OnEnable()
    {
        _ads.ShowInterstitialAds();
    }
}