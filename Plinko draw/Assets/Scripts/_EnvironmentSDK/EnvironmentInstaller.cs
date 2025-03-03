using Zenject;

public class EnvironmentInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        IEnvironmentDataWriteStrategy strategy = null;

        #if UNITY_EDITOR
            strategy = new DeviceEnvironmentWriteStrategy();
        #else
            #if UNITY_WEBGL
                strategy = new YandexEnvironmentDataWriteStrategy();
            #else
                strategy = new DeviceEnvironmentWriteStrategy();
            #endif
        #endif

        Container.Bind<EnvironmentFacade>().FromInstance(new EnvironmentFacade(strategy)).AsSingle().NonLazy();
    }
}