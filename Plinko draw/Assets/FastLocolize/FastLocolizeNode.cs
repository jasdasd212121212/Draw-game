using System;
using UnityEngine;

[Serializable]
public class FastLocolizeNode
{
    [SerializeField] private LanguageSettingsScriptableObject _language;
    [SerializeField] private string _text;

    public LanguageSettingsScriptableObject Language => _language;
    public string Text => _text;
}