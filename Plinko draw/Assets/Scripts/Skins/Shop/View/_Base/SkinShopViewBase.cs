using UnityEngine;
using Zenject;

public abstract class SkinShopViewBase : MonoBehaviour
{
    [Inject] private SkinShopPresenter _presenter;

    protected SkinShopPresenter Presenter => _presenter;

    protected void Awake()
    {
        _presenter.currentChanged += OnCurrentChanged;
        _presenter.modelLoaded += OnLoad;

        OnAwake();
    }

    protected void OnDestroy()
    {
        _presenter.currentChanged -= OnCurrentChanged;
        _presenter.modelLoaded -= OnLoad;

        OnDestroyed();
    }

    protected virtual void OnCurrentChanged(SkinShopSettingsDataNode skin) { }
    protected virtual void OnLoad() { }

    protected virtual void OnAwake() { }
    protected virtual void OnDestroyed() { }
}