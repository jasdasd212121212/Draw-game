using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class FreeCameraInputSystemInstaller : MonoInstaller
{
    [SerializeField] private EventTrigger _upButton;
    [SerializeField] private EventTrigger _downButton;

    public override void InstallBindings()
    {
        Container.Bind<IFreeCameraInputSystem>().FromInstance(new ToutchFreeCameraInputSystem(_upButton, _downButton)).AsSingle().NonLazy();
    }
}