using UnityEngine;

public class JumpBoost : BoosterTriggerBase
{
    [SerializeField] private float _boost;

    private Transform _cachedTransform;

    private void Start()
    {
        _cachedTransform = transform;
    }

    protected override void OnBodyEnter(Rigidbody2D body)
    {
        body.AddForce(_cachedTransform.up * _boost, ForceMode2D.Impulse);
    }
}