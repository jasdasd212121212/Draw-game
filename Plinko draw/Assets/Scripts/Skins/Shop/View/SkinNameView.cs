public class SkinNameView : SkinShopTextViewBase
{
    private void Start()
    {
        Text.text = Presenter.CurrentSkin.Name;
    }

    protected override void OnCurrentChanged(SkinShopSettingsDataNode skin)
    {
        Text.text = skin.Name;
    }
}