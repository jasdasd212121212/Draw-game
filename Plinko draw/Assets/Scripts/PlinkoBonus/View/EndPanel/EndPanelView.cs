using UnityEngine;

public class EndPanelView : PlinkoEndPanelViewBase
{
    [SerializeField] private GameObject _panel;

    protected override void OnFinish()
    {
        _panel.SetActive(true);
    }
}