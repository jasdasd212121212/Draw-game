using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class AdsFacade : MonoBehaviour, IAdsFacade
{
    [SerializeField] private GameObject _callbacksCollectorGameObject;

    private IAdsCallbacksCollector _callbacksCollector;

    private bool _isBusy;

    private Action rewardCallback;

#if UNITY_EDITOR
    private EditorAdsView _adsView;
#endif

    private void OnValidate()
    {
        if (_callbacksCollectorGameObject != null)
        {
            if (_callbacksCollectorGameObject.GetComponent<IAdsCallbacksCollector>() == null)
            {
                Debug.LogError($"Critical error -> can`t set a gameObject: {_callbacksCollectorGameObject} without any script realising {nameof(IAdsCallbacksCollector)}");
                _callbacksCollectorGameObject = null;
            }
        }
    }

    [Inject]
    private void Construct()
    {
        _callbacksCollector = _callbacksCollectorGameObject.GetComponent<IAdsCallbacksCollector>();

        _callbacksCollector.adsRewarded += OnReward;
        _callbacksCollector.adsClosed += OnClose;

#if UNITY_EDITOR
        if (_adsView == null)
        {
            _adsView = new EditorAdsView();
        }
#endif
    }

    private void OnDestroy()
    {
        _callbacksCollector.adsRewarded -= OnReward;
        _callbacksCollector.adsClosed -= OnClose;
    }

    public void ShowInterstitialAds()
    {
        if (_isBusy == true)
        {
            return;
        }

        Application.ExternalCall("ShowInterADS");

        _isBusy = true;

#if UNITY_EDITOR
        if (_adsView == null)
        {
            _adsView = new EditorAdsView();
        }

        EditroClose();

        _adsView.ShowEditorAds(this);
        _callbacksCollector.OpenCallback();
#endif
    }

    public void ShowRewardedAds(Action rewardCallback)
    {
        if (_isBusy == true)
        {
            return;
        }

        this.rewardCallback = rewardCallback;
        Application.ExternalCall("ShowRewADS");

        _isBusy = true;

#if UNITY_EDITOR
        StartCoroutine(EditorReward());
        EditroClose();

        _adsView.ShowEditorAds(this);
        _callbacksCollector.OpenCallback();
#endif
    }

    private void OnReward()
    {
        rewardCallback();
    }

    private void OnClose()
    {
        _isBusy = false;
    }

#if UNITY_EDITOR
    private IEnumerator EditorReward()
    {
        yield return new WaitForSecondsRealtime(3f);

        OnReward();
        _isBusy = false;
    }

    private void EditroClose()
    {
        StartCoroutine(CloseCallbackCallerCoroutinue());
    }

    private IEnumerator CloseCallbackCallerCoroutinue()
    {
        yield return new WaitForSecondsRealtime(3);
        _callbacksCollector.CloseCallback();
    }
#endif
}