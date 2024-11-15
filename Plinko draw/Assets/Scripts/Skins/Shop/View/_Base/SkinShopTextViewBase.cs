using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public abstract class SkinShopTextViewBase : SkinShopViewBase
{
    protected TMP_TextLocolizer Text { get; private set; }
    protected TextMeshProUGUI TmpText { get; private set; }

    protected override void OnAwake()
    {
        Text = GetComponent<TMP_TextLocolizer>();
        TmpText = GetComponent<TextMeshProUGUI>();
    }
}