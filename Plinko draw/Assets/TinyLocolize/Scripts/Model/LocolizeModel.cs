using UnityEngine;
using System.Linq;
using Cysharp.Threading.Tasks;

public class LocolizeModel
{
    private ILocolizeSerializer _parser;
    private ILocalLoader _localLoader;

    public LocolizeModel(ILocolizeSerializer parser, ILocalLoader loader)
    {
        _parser = parser;
        _localLoader = loader;
    }

    public string Locolize(string key, LanguageSettingsScriptableObject language, LanguagesHolderScriptableObject holder)
    {
        for (int i = 0; i < _parser.Locolize.Nodes.Length; i++)
        {
            if (_parser.Locolize.Nodes[i].Key == key)
            {
                return _parser.Locolize.Nodes[i].Locolizes[holder.Languages.ToList().IndexOf(language)];
            }
        }

        return "ERROR -> Not existing error";
    }

    public async UniTask<string[]> GetAllLocolizes(string key, int languagesCount)
    {
        await Fecth();

        for (int i = 0; i < _parser.Locolize.Nodes.Length; i++)
        {
            if (_parser.Locolize.Nodes[i].Key == key)
            {
                return _parser.Locolize.Nodes[i].Locolizes;
            }
        }

        return new string[languagesCount];
    }

    public async UniTask Fecth()
    {
        _parser.GetDeserialized(await _localLoader.LoadLocal());
    }
}