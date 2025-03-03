using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class LevelProgressModel : ISaveble<LevelProgressSaveData>
{
    private int _maxCompleatedLevelIndex;
    private int _currentLevelIndex;

    private LevelSettings _settings;

    public int MaxCompleatedLevelIndex => _maxCompleatedLevelIndex;
    public int CurrentLevelIndex => _currentLevelIndex;
    public int LevelsCount => _settings.LevelsCount;    

    public event Action dataChecnged;
    public event Action loaded;

    public LevelProgressModel(LevelSettings settings) 
    {
        _settings = settings;
    }

    public void CompleateLevel()
    {
        if (_currentLevelIndex == _maxCompleatedLevelIndex)
        {
            _maxCompleatedLevelIndex++;
        }
        
        _maxCompleatedLevelIndex = Mathf.Clamp(_maxCompleatedLevelIndex, 0, _settings.LevelsCount - 1);
    
        dataChecnged?.Invoke();
    }

    public void NextLevel()
    {
        _currentLevelIndex++;

        if(_currentLevelIndex >= _settings.Levels.Length)
        {
            _currentLevelIndex = 0;
        }

        SetCurrentLevel(_currentLevelIndex);
    }

    public void SetCurrentLevel(int currentLevel)
    {
        _currentLevelIndex = Mathf.Clamp(currentLevel, 0, _maxCompleatedLevelIndex);

        dataChecnged?.Invoke();
    }

    public async UniTask<LevelProgressSaveData> GetData(bool isFirstLoad)
    {
        await UniTask.Delay(0);
        return new LevelProgressSaveData(_maxCompleatedLevelIndex, _currentLevelIndex);
    }

    public void SetData(LevelProgressSaveData data)
    {
        _maxCompleatedLevelIndex = data.MaxCompleatedLevel;
        _currentLevelIndex = data.CurrentLevelIndex;

        loaded?.Invoke();
    }
}