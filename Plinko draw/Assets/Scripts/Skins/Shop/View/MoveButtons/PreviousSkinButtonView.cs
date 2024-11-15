public class PreviousSkinButtonView : SkinShopButtonViewBase
{
    protected override void OnClick()
    {
        Presenter.Previous();
    }
}