using UnityEngine;
using Zenject;

public class LevelSettingsInstaller : MonoInstaller
{
    [SerializeField] private LevelSettings _settings;

    public override void InstallBindings()
    {
        Container.Bind<LevelSettings>().FromInstance(_settings).AsSingle().Lazy();
    }
}