using UnityEngine;

public class EndPanelSoundView : PlinkoEndPanelViewBase
{
    [SerializeField] protected AudioSource _sound;

    protected override void OnFinish()
    {
        _sound.Play();
    }
}