using UnityEngine;

[RequireComponent(typeof(BoosterTriggerBase))]
public abstract class BoosterViewBase : MonoBehaviour
{
    [SerializeField] private bool _handleEnter;
    [SerializeField] private bool _handleStay;

    private BoosterTriggerBase _model;

    private void Awake()
    {
        _model = GetComponent<BoosterTriggerBase>();

        _model.entered += OnEnterCallback;
        _model.stay += OnStayCallback;
    }

    private void OnDestroy()
    {
        _model.entered -= OnEnterCallback;
        _model.stay -= OnStayCallback;
    }

    private void OnEnterCallback()
    {
        if (_handleEnter == false)
        {
            return;
        }

        OnEnter();
    }

    private void OnStayCallback()
    {
        if (_handleStay == false)
        {
            return;
        }

        OnStay();
    }

    protected virtual void OnEnter() { }
    protected virtual void OnStay() { }
}