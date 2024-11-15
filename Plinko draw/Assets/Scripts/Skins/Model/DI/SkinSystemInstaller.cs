using Zenject;

public class SkinSystemInstaller : MonoInstaller
{
    [Inject] private SkinShopSettings _settings;
    [Inject] private ISavingSystem _savingSystem;

    public override void InstallBindings()
    {
        SkinSystemModel model = new SkinSystemModel(_settings);
        new SaverComponent<SkinSystemSaveData>(SavingConfig.SKINS_SAVE_KEY, model, _savingSystem);

        Container.Bind<SkinSystemModel>().FromInstance(model).AsSingle().NonLazy();
    }
}