using Cysharp.Threading.Tasks;
using UnityEngine;

public static class LocolizeSystemFacade
{
    private static LocolizeModel _model;
    private static LocolizeSettingsModel _settingsModel;
    private static LanguagesHolderScriptableObject _holder;
    private static ILocolizeSerializer _parser;

    private static bool _initialized;

    public static int LanguagesCount => _parser.LanguagesCount;

    public static void Initialize(ILocolizeSerializer parser, ILocalLoader loader, LanguagesHolderScriptableObject languages)
    {
        if (_initialized == true)
        {
            return;
        }

        _model = new LocolizeModel(parser, loader);
        _holder = languages;
        _parser = parser;
    }

    public static void Initialize(ILocolizeSerializer parser, ILocalLoader loader, LanguagesHolderScriptableObject holder, LocolizeSettingsModel settings)
    {
        if (_initialized == true)
        {
            return;
        }

        _settingsModel = settings;
        Initialize(parser, loader, holder);
        _holder = holder;

        _initialized = true;
    }

    public static async UniTask<string> GetLoclized(string key)
    {
        await UniTask.WaitWhile(() => _model == null);

        return _model.Locolize(key, _settingsModel.CurrentLanguage, _holder);
    }

    public static async UniTask<string[]> GetAllLocolizes(string key, int languagesCount)
    {
        if (_model == null)
        {
            return new string[] { "ERROR -> system not initialized" };
        }

        return await _model.GetAllLocolizes(key, languagesCount);
    }

    public static int GetIdOfLanguageByName(string languageName)
    {
        for (int i = 0; i < _holder.Languages.Length; i++)
        {
            if (_holder.Languages[i].Name == languageName)
            {
                return i;
            }
        }

        Debug.LogError($"Critical error -> no one alnguage by name: {languageName}");
        return 0;
    }
}