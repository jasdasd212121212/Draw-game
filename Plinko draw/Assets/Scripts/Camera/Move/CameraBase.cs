using UnityEngine;
using Zenject;

public abstract class CameraBase : MonoBehaviour
{
    [Inject] private LevelSpawner _spawner;

    private Transform _cachedTransform;
    protected float MinimalY { get; private set; }

    protected Vector3 Position => _cachedTransform.position;

    [Inject]
    private void Construct()
    {
        _cachedTransform = transform;
        _spawner.levelSpawned += OnSpawnLevel;

        Initialized();
    }

    private void OnDestroy()
    {
        _spawner.levelSpawned -= OnSpawnLevel;

        Destroyed();
    }

    private void OnSpawnLevel(LevelPrefab level)
    {
        MinimalY = level.Deepenes;
    }

    protected void SetPosition(Vector3 position)
    {
        _cachedTransform.position = new Vector3(position.x, Mathf.Clamp(position.y, MinimalY, 0f), position.z);
    }

    protected virtual void Initialized() { }
    protected virtual void Destroyed() { }
}