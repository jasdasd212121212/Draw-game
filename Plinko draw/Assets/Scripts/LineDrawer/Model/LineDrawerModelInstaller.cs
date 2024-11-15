using Zenject;

public class LineDrawerModelInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<LineDrawModel>().FromInstance(new LineDrawModel()).AsSingle().NonLazy();
    }
}