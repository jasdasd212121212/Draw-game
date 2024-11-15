using Zenject;

public class WalletInstaller : MonoInstaller
{
    [Inject] private ISavingSystem _savingSystem;

    public override void InstallBindings()
    {
        WalletModel walletModel = new WalletModel();
        new SaverComponent<WalletSaveData>(SavingConfig.WALLET_SAVE_KEY, walletModel, _savingSystem);

        Container.Bind<WalletModel>().FromInstance(walletModel).AsSingle().Lazy();
    }
}