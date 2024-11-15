using UnityEngine;

public class SoundsActivityStateMachine : MonoBehaviour
{
    [SerializeField] private GameObject _callbacksCollectorGameObject;

    private IAdsCallbacksCollector _callbacksCollector;

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

    private void Awake()
    {
        _callbacksCollector = _callbacksCollectorGameObject.GetComponent<IAdsCallbacksCollector>();

        _callbacksCollector.adsStarted += OnOpen;
        _callbacksCollector.adsClosed += OnClose;
    }

    private void OnDestroy()
    {
        _callbacksCollector.adsStarted -= OnOpen;
        _callbacksCollector.adsClosed -= OnClose;
    }

    private void OnOpen()
    {
        AudioListener.volume = 0;
    }

    private void OnClose()
    {
        AudioListener.volume = 1;
    }
}