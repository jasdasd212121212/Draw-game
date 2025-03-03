using Cysharp.Threading.Tasks;
using UnityEngine;

public class LocolizeOptionPresenter : BaseOptionPresenter<IntDataTransferObject>
{
    private LocolizeSettingsModel _settingsModel;
    private EnvironmentFacade _environmentFacade;
    private LocolizeSettingsModel _locolize;

    private const string CACHED_DEFAULT_DATA_SAVE_KEY = "_cachedLocolize";

    public LocolizeOptionPresenter(BaseOptionView<IntDataTransferObject> view, LocolizeSettingsModel settingsModel, EnvironmentFacade environmentFacade, LocolizeSettingsModel locolize) : base(view)
    {
        _settingsModel = settingsModel;
        _environmentFacade = environmentFacade;
        _locolize = locolize;
    }

    protected override void Apply(IntDataTransferObject data)
    {
        _settingsModel.SetLanguage(data.Data);
    }

    protected override async UniTask<BaseOptionPresenterDataValidationCallback<IntDataTransferObject>> ValidateDefaultData(IntDataTransferObject currentDefaultData)
    {
        if (!PlayerPrefs.HasKey(CACHED_DEFAULT_DATA_SAVE_KEY))
        {
            PlayerPrefs.SetInt(CACHED_DEFAULT_DATA_SAVE_KEY, currentDefaultData.Data);

            Debug.Log($"Locolize cache is INITIALIZING as {currentDefaultData.Data}");

            return new(true, null);
        }

        int loadedCahce = PlayerPrefs.GetInt(CACHED_DEFAULT_DATA_SAVE_KEY);
        bool isValidData = loadedCahce == currentDefaultData.Data;
        IntDataTransferObject validCache = null;

        if (isValidData == false)
        {
            validCache = await GetDefaultData();
            PlayerPrefs.SetInt(CACHED_DEFAULT_DATA_SAVE_KEY, validCache.Data);
        }

        Debug.Log($"Locolize cache {(isValidData ? "" : "NOT")} VALID {(isValidData ? "" : $"{loadedCahce} != {validCache.Data}")}");

        return new(isValidData, validCache);
    }

    protected override async UniTask<IntDataTransferObject> GetDefaultData()
    {
        LanguageDataSegment languageEnvironmentData = await _environmentFacade.Data.ReadSegment<LanguageDataSegment>();

        Debug.Log($"Defined paltform language: {languageEnvironmentData.IsoCode} (ISO)");

        return new IntDataTransferObject(_locolize.GetLanguageIndexByIsoCode(languageEnvironmentData.IsoCode));
    }
}