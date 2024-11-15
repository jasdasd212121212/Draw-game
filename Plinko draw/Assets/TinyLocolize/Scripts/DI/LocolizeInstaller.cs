using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class LocolizeInstaller : MonoInstaller
{
    [SerializeField] private LanguagesHolderScriptableObject _languages;
    [SerializeField] private bool _useWebGlLoader = true;

    public override void InstallBindings()
    {
        ILocalLoader loader = null;

#if UNITY_EDITOR
        loader = new LocalFileStreamingAssetsLoader();
#else
        if (_useWebGlLoader == true)
        {
            loader = new WebGlLocalFileLoader();
        }
        else
        {
            loader = new LocalFileStreamingAssetsLoader();
        }
#endif

        LocolizeSettingsModel settingsModel = new LocolizeSettingsModel(_languages);

        Container.Bind<LocolizeSettingsModel>().FromInstance(settingsModel).AsSingle().NonLazy();
        Initialize(loader, settingsModel).Forget();
    }

    private async UniTask Initialize(ILocalLoader loader, LocolizeSettingsModel settingsModel)
    {
        LocolizeSystemFacade.Initialize(new LocalizeFileParser(await loader.LoadLocal()), loader, _languages, settingsModel);
    }
}