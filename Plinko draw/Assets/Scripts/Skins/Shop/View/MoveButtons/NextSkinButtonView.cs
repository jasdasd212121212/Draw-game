public class NextSkinButtonView : SkinShopButtonViewBase
{
    protected override void OnClick()
    {
        Presenter.Next();
    }
}