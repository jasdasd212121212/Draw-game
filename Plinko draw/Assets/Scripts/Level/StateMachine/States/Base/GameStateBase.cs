public abstract class GameStateBase : State
{
    private ILevelElementActiveSettable[] _activatebleElements;
    private ILevelElementActiveSettable[] _inactivatebleElements;

    public GameStateBase(ILevelElementActiveSettable[] activatebleElements, ILevelElementActiveSettable[] inactivatebleElements) 
    {
        _activatebleElements = activatebleElements;
        _inactivatebleElements = inactivatebleElements;
    }

    public override void OnEnter()
    {
        OnEnterState();

        SetActiveFor(_activatebleElements, true);
        SetActiveFor(_inactivatebleElements, false);
    }

    public override void OnExit()
    {
        OnExitedState();
    }

    protected virtual void OnEnterState() { }
    protected virtual void OnExitedState() { }

    protected void SetActiveFor(ILevelElementActiveSettable[] targets, bool state)
    {
        if (targets == null)
        {
            return;
        }

        foreach (ILevelElementActiveSettable target in targets)
        {
            target.SetActive(state);
        }
    }
}