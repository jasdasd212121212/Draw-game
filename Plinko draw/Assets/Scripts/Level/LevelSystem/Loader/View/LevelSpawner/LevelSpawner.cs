using System;
using UnityEngine;
using Zenject;

public class LevelSpawner : MonoBehaviour
{
    [Inject] private LevelProgressModel _progress;
    [Inject] private LevelSettings _settings;

    private MonoFactory<LevelPrefab> _levelFactory;

    public LevelPrefab CurrentLevel { get; private set; }

    public event Action<LevelPrefab> levelSpawned;
    public event Action<LevelPrefab> levelDestroyed;

    [Inject]
    private void Constrcut()
    {
        _levelFactory = new MonoFactory<LevelPrefab>();
        _progress.loaded += OnLoad;
    }

    private void Awake()
    {
        OnLoad();
    }

    private void OnDestroy()
    {
        _progress.loaded -= OnLoad;
    }

    private void OnLoad()
    {
        SpawnLevel(_settings.Levels[_progress.CurrentLevelIndex]);
    }

    private void SpawnLevel(LevelPrefab level)
    {
        if (CurrentLevel != null)
        {
            levelDestroyed?.Invoke(CurrentLevel);
            Destroy(CurrentLevel.gameObject);
        }

        CurrentLevel = _levelFactory.Create(level, Vector3.zero, Quaternion.identity);
        levelSpawned?.Invoke(CurrentLevel);
    }
}