using UnityEngine;
using Zenject;

public class AdsRewardButtonInstaller : MonoInstaller
{
    [SerializeField] private int _reward;

    [Inject] private IAdsFacade _ads;
    [Inject] private WalletModel _wallet;

    public override void InstallBindings()
    {
        Container.Bind<AdsRewardButtonModel>().FromInstance(new AdsRewardButtonModel(_ads, _reward, _wallet)).AsSingle().NonLazy();
    }
}