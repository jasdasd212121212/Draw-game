using UnityEngine;

public class SkinCostFieldVisibilityView : SkinShopViewBase
{
    [SerializeField] private GameObject _field;

    private void Start()
    {
        _field.SetActive(!Presenter.SkinIsBuyed(Presenter.CurrentSkin));
    }

    protected override void OnLoad()
    {
        _field.SetActive(!Presenter.SkinIsBuyed(Presenter.CurrentSkin));
    }

    protected override void OnCurrentChanged(SkinShopSettingsDataNode skin)
    {
        _field.SetActive(!Presenter.SkinIsBuyed(skin));
    }
}