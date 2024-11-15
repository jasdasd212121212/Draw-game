using UnityEngine;
using Zenject;

public class GameStateMachineModel : MonoBehaviour
{
    [SerializeField] private PlayerBall _player;
    [SerializeField] private FreeCameraActivityElement _camera;

    [Inject] private LevelSpawner _levelSpawner;

    private NotStartedState _notStartedState;
    private GameplayState _gameState;
    private FinishedState _finishedState;

    private StateMachine _stateMachine;

    public IReadOnlyStateMachine StateMachine => _stateMachine;

    [Inject]
    private void Constrcut()
    {
        _levelSpawner.levelSpawned += OnLevelSpawned;
        _levelSpawner.levelDestroyed += OnLevelDestroyed;
    }

    private void Awake()
    {
        _notStartedState = new NotStartedState(new ILevelElementActiveSettable[] { _camera }, new ILevelElementActiveSettable[] { _player });  
        _gameState = new GameplayState(new ILevelElementActiveSettable[] { _player }, new ILevelElementActiveSettable[] { _camera });
        _finishedState = new FinishedState(null, new ILevelElementActiveSettable[] { _player, _camera });

        _stateMachine = new StateMachine(_notStartedState, _gameState, _finishedState);
        _stateMachine.ChangeState(_notStartedState);
    }

    private void OnDestroy()
    {
        _levelSpawner.levelSpawned += OnLevelSpawned;
        _levelSpawner.levelDestroyed += OnLevelDestroyed;

        OnLevelDestroyed(_levelSpawner.CurrentLevel);
    }

    public void StartGame()
    {
        _stateMachine.ChangeState(_gameState);
    }

    private void OnFinish()
    {
        _stateMachine.ChangeState(_finishedState);
    }

    private void OnLevelSpawned(LevelPrefab level)
    {
        if (level == null)
        {
            return;
        }

        if (level.Finish == null)
        {
            Debug.LogError($"Critical error -> finish in null on level: {level}");
            return;
        }

        level.Finish.finished += OnFinish;
    }

    private void OnLevelDestroyed(LevelPrefab level)
    {
        if(level == null)
        {
            return;
        }

        if (level.Finish == null)
        {
            Debug.LogError($"Critical error -> finish in null on level: {level}");
            return;
        }

        level.Finish.finished -= OnFinish;
    }
}