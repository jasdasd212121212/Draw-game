using UnityEngine;

public class GameScreenSoundView : GameViewBase
{
    [SerializeField] private AudioSource _winSound;

    protected override void OnFinish()
    {
        _winSound.Play();
    }
}