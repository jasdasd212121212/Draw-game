using System;
using UnityEngine;
using Zenject;

public class AdsCallbacksHandler : MonoBehaviour, IAdsCallbacksCollector
{
    [Inject] private PauseModel _pause;

    public event Action adsStarted;
    public event Action adsClosed;
    public event Action adsErrored;
    public event Action adsRewarded;

    [ContextMenu("Open")]
    public void OpenCallback()
    {
        _pause.SetPaused(true);
        adsStarted?.Invoke();
    }

    [ContextMenu("Close")]
    public void CloseCallback()
    {
        _pause.SetPaused(false);
        adsClosed?.Invoke();
    }

    private void ErrorCallback()
    {
        _pause.SetPaused(false);
        adsClosed.Invoke();
        adsErrored?.Invoke();
    }

    private void RewardedCallback()
    {
        adsRewarded.Invoke();
        adsClosed?.Invoke();
    }
}