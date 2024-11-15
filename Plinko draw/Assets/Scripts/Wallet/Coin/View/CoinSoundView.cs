using UnityEngine;

public class CoinSoundView : CoinViewBase
{
    [SerializeField] private AudioSource _sound;

    protected override void OnCollect()
    {
        _sound.transform.SetParent(null);
        _sound.Play();
    }
}