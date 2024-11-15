using UnityEngine;

[CreateAssetMenu(fileName = "Language", menuName = "Locolize/Settings/_Holder")]
public class LanguagesHolderScriptableObject : ScriptableObject
{
    [SerializeField] private LanguageSettingsScriptableObject[] _languages;

    public LanguageSettingsScriptableObject[] Languages => _languages;
}