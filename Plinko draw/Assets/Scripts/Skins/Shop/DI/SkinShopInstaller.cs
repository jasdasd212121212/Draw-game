using Zenject;

public class SkinShopInstaller : MonoInstaller
{
    [Inject] private SkinShopSettings _settings;
    [Inject] private SkinSystemModel _skinsSystem;
    [Inject] private WalletModel _wallet;

    public override void InstallBindings()
    {
        SkinShopSettingsDataNode[] skins = new SkinShopSettingsDataNode[_settings.Nodes.Length + 1];
        
        skins[0] = _settings.DefaultSkin;

        for (int i = 1; i < skins.Length; i++)
        {
            skins[i] = _settings.Nodes[i - 1];
        }

        SkinShopModel model = new SkinShopModel(skins, _skinsSystem);

        Container.Bind<SkinShopPresenter>().FromInstance(new SkinShopPresenter(_settings, _skinsSystem, model, _wallet)).AsSingle().NonLazy();
    }
}