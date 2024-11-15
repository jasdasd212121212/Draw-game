using UnityEngine;

public class ActionButtonTextView : SkinShopTextViewBase
{
    [SerializeField] private string _buyTextKey;
    [SerializeField] private string _chooseTextKey;
    [SerializeField] private string _chosenTextKey;

    protected override void OnLoad()
    {
        DisplayText(Presenter.CurrentSkin);
    }

    private void Start()
    {
        DisplayText(Presenter.CurrentSkin);
    }

    protected override void OnCurrentChanged(SkinShopSettingsDataNode skin)
    {
        DisplayText(skin);
    }

    private void DisplayText(SkinShopSettingsDataNode skin)
    {
        if (Presenter.SkinIsBuyed(skin) == false)
        {
            Text.text = _buyTextKey;
        }
        else
        {
            if (Presenter.SkinIsChoosed(skin) == false)
            {
                Text.text = _chooseTextKey;
            }
            else
            {
                Text.text = _chosenTextKey;
            }
        }
    }
}