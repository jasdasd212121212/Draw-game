using UnityEngine;

public class LineSoundView : LineViewRoundBase
{
    [SerializeField] private AudioSource _sound;

    public override void OnAddPoint(Vector3 point)
    {
        if (_sound.isPlaying == false)
        {
            _sound.Play();
        }
    }

    public override void OnEndLine(Vector3[] points)
    {
        _sound.Stop();
    }
}