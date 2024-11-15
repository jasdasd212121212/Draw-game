using UnityEngine;

public class CoinParticlesView : CoinViewBase
{
    [SerializeField] private ParticleSystem _particles;

    protected override void OnCollect()
    {
        _particles.transform.SetParent(null);
        _particles.Play();
    }
}