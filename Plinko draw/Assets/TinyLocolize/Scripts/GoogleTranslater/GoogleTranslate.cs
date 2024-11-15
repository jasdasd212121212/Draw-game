using Cysharp.Threading.Tasks;
using System.Text;
using UnityEngine;

public class GoogleTranslate
{
    private GoogleTranlateParser _parser;
    private GoogleTranslateApiNetworkRequier _requier;

    public GoogleTranslate()
    {
        _parser = new GoogleTranlateParser();
        _requier = new GoogleTranslateApiNetworkRequier();
    }

    public async UniTask<string> Translate(string isoCodeFrom, string isoCodeTo, string source)
    {
        if (string.IsNullOrEmpty(RemoveSpecialCharacters(source)))
        {
            Debug.LogError("Critical error -> Empty source error!");
            return "";
        }

        string raw = await _requier.RequireTranslate(isoCodeFrom.Trim(), isoCodeTo.Trim(), RemoveSpecialCharacters(source));
        return _parser.Parse(raw);
    }

    public string RemoveSpecialCharacters(string str)
    {
        StringBuilder sb = new StringBuilder();

        foreach (char c in str)
        {
            if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= 'À' && c <= 'ß') || (c >= 'à' && c <= 'ÿ') || c == '.' || c == '_' || c == ' ')
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }
}