using UnityEngine;

[CreateAssetMenu(fileName = "Levels", menuName = "Game design/Levels")]
public class LevelSettings : ScriptableObject
{
    [SerializeField][Min(0)] private int _gameplaySceneIndex;
    [SerializeField][Min(0)] private int _mainMenuSceneIndex;
    [SerializeField][Min(0)] private int _bonusSceneIndex;

    [Space]

    [SerializeField] private LevelPrefab[] _levels;

    public LevelPrefab[] Levels => _levels;
    public int LevelsCount => _levels.Length;

    public int GameplaySceneIndex => _gameplaySceneIndex;
    public int MainMenuSceneIndex => _mainMenuSceneIndex;
    public int BonusSceneIndex => _bonusSceneIndex;
}