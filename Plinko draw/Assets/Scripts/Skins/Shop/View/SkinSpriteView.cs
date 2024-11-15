using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Image))]
public class SkinSpriteView : SkinShopViewBase
{
    private Image _image;

    protected override void OnAwake()
    {
        _image = GetComponent<Image>();
        _image.sprite = Presenter.CurrentSkin.Skin;
    }

    protected override void OnCurrentChanged(SkinShopSettingsDataNode skin)
    {
        _image.sprite = skin.Skin;
    }
}