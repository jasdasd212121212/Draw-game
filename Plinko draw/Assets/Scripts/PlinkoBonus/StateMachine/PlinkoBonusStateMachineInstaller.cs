using UnityEngine;
using Zenject;

public class PlinkoBonusStateMachineInstaller : MonoInstaller
{
    [SerializeField] private PlinkoBonusStateMachine _stateMachine;

    public override void InstallBindings()
    {
        Container.Bind<PlinkoBonusStateMachine>().FromInstance(_stateMachine).AsSingle().Lazy();
    }
}