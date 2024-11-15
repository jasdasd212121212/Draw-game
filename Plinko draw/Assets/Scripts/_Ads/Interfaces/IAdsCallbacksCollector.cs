using System;

public interface IAdsCallbacksCollector
{
    event Action adsStarted;
    event Action adsClosed;
    event Action adsErrored;
    event Action adsRewarded;

    void OpenCallback();
    void CloseCallback();
}