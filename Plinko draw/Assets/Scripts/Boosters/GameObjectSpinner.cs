using UnityEngine;

public class GameObjectSpinner : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _cachedTransform;

    private void Awake()
    {
        _cachedTransform = transform;
    }

    private void Update()
    {
        _cachedTransform.Rotate(Vector3.forward, _speed * Time.deltaTime);
    }
}