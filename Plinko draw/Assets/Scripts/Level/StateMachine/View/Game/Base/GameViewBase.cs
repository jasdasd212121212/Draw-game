using UnityEngine;
using Zenject;

public abstract class GameViewBase : MonoBehaviour
{
    [Inject] private GameStateMachineModel _stateMachine;

    private void Start()
    {
        _stateMachine.StateMachine.GetState<FinishedState>().entered += OnFinish;
    }

    private void OnDestroy()
    {
        _stateMachine.StateMachine.GetState<FinishedState>().entered -= OnFinish;
    }

    protected virtual void OnFinish() { }
}