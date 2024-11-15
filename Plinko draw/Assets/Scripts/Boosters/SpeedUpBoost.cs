using UnityEngine;

public class SpeedUpBoost : BoosterTriggerBase
{
    [SerializeField][Min(0)] private float _force;

    private Transform _cachedTransform;

    private void Start()
    {
        _cachedTransform = transform;
    }

    protected override void OnBodyStay(Rigidbody2D body)
    {
        body.AddForce(_cachedTransform.right * _force, ForceMode2D.Force);
    }
}