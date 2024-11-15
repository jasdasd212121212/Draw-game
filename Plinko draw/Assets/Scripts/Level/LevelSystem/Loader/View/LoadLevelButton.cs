using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(ZenAutoInjecter))]
public class LoadLevelButton : LevelButtonBase
{
    private int _targetLevel;
    private bool _initialized;

    public Button Button => SelfButton;
    public int TargetLevel => _targetLevel;

    public void Initialize(int targetLevel)
    {
        if (_initialized == true)
        {
            return;
        }

        _targetLevel = targetLevel;
    
        _initialized = true;
    }

    protected override void OnClicked()
    {
        Model.LoadLevel(_targetLevel);
    }
}