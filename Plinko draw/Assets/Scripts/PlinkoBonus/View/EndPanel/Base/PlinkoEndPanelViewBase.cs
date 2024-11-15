using UnityEngine;
using Zenject;

public abstract class PlinkoEndPanelViewBase : MonoBehaviour
{
    [Inject] private PlinkoBonusStateMachine _stateMachine;

    protected void Start()
    {
        _stateMachine.StateMachine.GetState<PlinkoEndedState>().entered += OnFinish;
    }

    protected void OnDestroy()
    {
        _stateMachine.StateMachine.GetState<PlinkoEndedState>().entered -= OnFinish;
    }

    protected abstract void OnFinish();
}