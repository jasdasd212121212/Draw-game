using Zenject;

public class SavingSystemInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ISavingSystem>().FromInstance(new PlayerPrefsJsonSaver()).AsSingle().NonLazy();
    }
}