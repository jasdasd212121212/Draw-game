using System;
using UnityEngine;

public class LineDrawerAmountModel
{
    private int _amount;
    private int _maximalAmount;

    private LevelSpawner _spawner;

    public int Amount => _amount;
    public int MaximalAmount => _maximalAmount;

    public event Action amountChanged;

    public LineDrawerAmountModel(LevelSpawner spawner)
    {
        _spawner = spawner;
        _spawner.levelSpawned += OnSpawnLevel;
    }

    ~LineDrawerAmountModel()
    {
        if (_spawner != null)
        {
            _spawner.levelSpawned -= OnSpawnLevel;
        }
    }

    public void DecreaseAmount()
    {
        _amount--;
        _amount = Mathf.Clamp(_amount, 0, _maximalAmount);

        amountChanged?.Invoke();
    }

    private void OnSpawnLevel(LevelPrefab level)
    {
        _amount = level.DrawAmount;
        _maximalAmount = _amount;

        amountChanged?.Invoke();
    }
}