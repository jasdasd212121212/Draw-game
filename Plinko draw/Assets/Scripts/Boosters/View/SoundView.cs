using UnityEngine;

public class SoundView : BoosterViewBase
{
    [SerializeField] private AudioSource _enterSound;
    [SerializeField] private AudioSource _staySound;

    protected override void OnEnter()
    {
        if (_enterSound.isPlaying == false)
        {
            _enterSound.Play();
        }
    }

    protected override void OnStay()
    {
        if (_staySound.isPlaying == false)
        {
            _staySound.Play();
        }
    }
}