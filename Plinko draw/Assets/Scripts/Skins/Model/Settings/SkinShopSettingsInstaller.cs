using UnityEngine;
using Zenject;

public class SkinShopSettingsInstaller : MonoInstaller
{
    [SerializeField] private SkinShopSettings _settings;

    public override void InstallBindings()
    {
        Container.Bind<SkinShopSettings>().FromInstance(_settings).AsSingle().Lazy();
    }
}