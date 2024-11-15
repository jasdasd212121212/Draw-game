using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsLoader
{
    private LevelSettings _settings;
    private LevelProgressModel _progressModel;

    public LevelsLoader(LevelSettings settings, LevelProgressModel progress) 
    {
        _settings = settings;
        _progressModel = progress;
    }

    public void LoadLevel(int index)
    {
        if (index < 0 || index > (_settings.LevelsCount - 1))
        {
            Debug.LogError($"Critical error -> can`t load level by index: {index} -> invalid bounds --- BOUNDS: (0, {_settings.LevelsCount - 1})");
            return;
        }

        _progressModel.SetCurrentLevel(index);
        SceneManager.LoadScene(_settings.GameplaySceneIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(_settings.MainMenuSceneIndex);
    }

    public void LoadBonusScene()
    {
        SceneManager.LoadScene(_settings.BonusSceneIndex);
    }
}