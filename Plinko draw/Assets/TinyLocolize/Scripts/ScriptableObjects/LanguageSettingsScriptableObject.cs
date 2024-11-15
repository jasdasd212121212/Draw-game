using UnityEngine;

[CreateAssetMenu(fileName = "Language", menuName = "Locolize/Language")]
public class LanguageSettingsScriptableObject : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _isoCode;

    public string Name => _name;
    public string IsoCode => _isoCode;
}