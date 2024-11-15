using Zenject;

public class LevelsLoaderInstaller : MonoInstaller
{
    [Inject] private LevelSettings _settings;
    [Inject] private LevelProgressModel _progress;

    public override void InstallBindings()
    {
        LevelsLoader loader = new LevelsLoader(_settings, _progress);

        Container.Bind<LevelsLoader>().FromInstance(loader).AsSingle().NonLazy();
        Container.Bind<LevelsLoaderPresenter>().FromInstance(new LevelsLoaderPresenter(loader, _progress)).AsSingle().NonLazy();
    }
}