using Zenject;
using UnityEngine;

public class LevelsPanelView : MonoBehaviour
{
    [SerializeField] private LoadLevelButton _buttonPrefab;

    [Inject] private LevelProgressModel _progressModel;

    private MonoFactory<LoadLevelButton> _buttonFactory;

    private void Start()
    {
        _buttonFactory = new MonoFactory<LoadLevelButton>(_buttonPrefab, transform);
        Display();
    }

    private void Display()
    {
        for (int i = 0; i < _progressModel.LevelsCount; i++)
        {
            CreateButton(i);
        }
    }

    private void CreateButton(int levelIndex)
    {
        LoadLevelButton button = _buttonFactory.Create();
        button.Initialize(levelIndex);

        button.Button.interactable = levelIndex > _progressModel.MaxCompleatedLevelIndex ? false : true;
    }
}