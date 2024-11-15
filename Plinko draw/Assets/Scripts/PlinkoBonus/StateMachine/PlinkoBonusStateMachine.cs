using UnityEngine;
using Zenject;

public class PlinkoBonusStateMachine : MonoBehaviour
{
    [Inject] private WalletModel _wallet;
    [Inject] private PlinkoBonusModel _model;

    private StateMachine _stateMachine;

    private PlinkoPlayingState _playingState;
    private PlinkoEndedState _endedState;

    public IReadOnlyStateMachine StateMachine => _stateMachine;

    private void Awake()
    {
        _playingState = new PlinkoPlayingState();
        _endedState = new PlinkoEndedState(_wallet, _model);

        _stateMachine = new StateMachine(_playingState, _endedState);
        _stateMachine.ChangeState(_playingState);

        _model.ended += OnEnd;
    }

    private void OnDestroy()
    {
        _model.ended -= OnEnd;
    }

    public void Abort()
    {
        _stateMachine.ChangeState(_endedState);
    }

    private void OnEnd()
    {
        Abort();
    }
}