using UnityEngine;
using Zenject;

public class LineDrawerSettingsInstaller : MonoInstaller
{
    [SerializeField] private LineDrawerSettings _settings;

    public override void InstallBindings()
    {
        Container.Bind<LineDrawerSettings>().FromInstance(_settings).AsSingle().NonLazy();   
    }
}