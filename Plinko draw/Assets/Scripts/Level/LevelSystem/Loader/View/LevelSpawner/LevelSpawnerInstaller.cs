using UnityEngine;
using Zenject;

public class LevelSpawnerInstaller : MonoInstaller
{
    [SerializeField] private LevelSpawner _spawner;

    public override void InstallBindings()
    {
        Container.Bind<LevelSpawner>().FromInstance(_spawner).AsSingle().Lazy();
    }
}