using Zenject;

public class PauseModelInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PauseModel>().FromInstance(new PauseModel()).AsSingle().NonLazy();
    }
}