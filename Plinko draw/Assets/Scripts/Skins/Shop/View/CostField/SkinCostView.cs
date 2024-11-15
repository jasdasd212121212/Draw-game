public class SkinCostView : SkinShopTextViewBase
{
    private void Start()
    {
        Display(Presenter.CurrentSkin);
    }

    protected override void OnCurrentChanged(SkinShopSettingsDataNode skin)
    {
        Display(skin);
    }

    private void Display(SkinShopSettingsDataNode skin)
    {
        TmpText.text = skin.Cost.ToString();
    }
}