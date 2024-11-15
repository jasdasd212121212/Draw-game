using UnityEngine.Events;

public class ActionButtonView : SkinShopButtonViewBase
{
    protected override void OnLoad()
    {
        Handle(Presenter.CurrentSkin);
    }

    private void Start()
    {
        Handle(Presenter.CurrentSkin);
    }

    protected override void OnCurrentChanged(SkinShopSettingsDataNode skin)
    {
        Handle(skin);
    }

    private void Handle(SkinShopSettingsDataNode skin)
    {
        if (Presenter.SkinIsBuyed(skin) == false)
        {
            SubscribeButton(Buy);
        }
        else
        {
            if (Presenter.SkinIsChoosed(skin) == false)
            {
                SubscribeButton(Choose);
            }
            else
            {
                Button.onClick.RemoveAllListeners();
            }
        }
    }

    private void SubscribeButton(UnityAction action)
    {
        Button.onClick.RemoveAllListeners();
        Button.onClick.AddListener(action);
    }

    private void Buy()
    {
        Presenter.Buy();
    }

    private void Choose()
    {
        Presenter.Choose();
    }
}