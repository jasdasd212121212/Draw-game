using Zenject;

public class LineDrawerAmountInstaller : MonoInstaller
{
    [Inject] private LevelSpawner _spawner;

    public override void InstallBindings()
    {
        Container.Bind<LineDrawerAmountModel>().FromInstance(new LineDrawerAmountModel(_spawner)).AsSingle().Lazy();
    }
}