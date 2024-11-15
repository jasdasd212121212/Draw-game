using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class SkinShopButtonViewBase : SkinShopViewBase
{
    protected Button Button { get; private set; }

    protected override void OnAwake()
    {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(OnClick);
    }

    protected override void OnDestroyed()
    {
        Button.onClick.RemoveAllListeners();
    }

    protected virtual void OnClick() { }
}