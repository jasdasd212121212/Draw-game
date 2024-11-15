using UnityEngine;
using Zenject;

public class GameStateMachineInstaller : MonoInstaller
{
    [SerializeField] private GameStateMachineModel _model;

    public override void InstallBindings()
    {
        Container.Bind<GameStateMachineModel>().FromInstance(_model).AsSingle().Lazy();
    }
}