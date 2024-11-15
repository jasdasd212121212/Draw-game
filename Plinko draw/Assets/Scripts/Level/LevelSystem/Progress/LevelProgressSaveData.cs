using System;
using UnityEngine;

[Serializable]
public class LevelProgressSaveData
{
    [SerializeField] private int _maxCompleatedLevel = 0;
    [SerializeField] private int _currentLevelIndex = 0;

    public int MaxCompleatedLevel => _maxCompleatedLevel;
    public int CurrentLevelIndex => _currentLevelIndex;

    public LevelProgressSaveData(int maxCompleatedLevel, int currentLevelIndex) 
    {
        _maxCompleatedLevel = maxCompleatedLevel;
        _currentLevelIndex = currentLevelIndex;
    }
}