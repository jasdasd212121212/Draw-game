using UnityEngine;

public class GameScreenView : GameViewBase
{
    [SerializeField] private GameObject _finishPanel;

    protected override void OnFinish()
    {
        _finishPanel.SetActive(true);
    }
}