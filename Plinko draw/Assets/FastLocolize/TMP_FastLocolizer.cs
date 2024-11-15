using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TMP_FastLocolizer : MonoBehaviour
{
    [SerializeField] private FastLocolizeNode[] _nodes;

    [Inject] private LocolizeSettingsModel _settingsModel;

    private void Start()
    {
        LanguageSettingsScriptableObject currentLanguage = _settingsModel.CurrentLanguage;

        foreach (FastLocolizeNode node in _nodes)
        {
            if (node.Language == currentLanguage)
            {
                GetComponent<TextMeshProUGUI>().text = node.Text;
                return;
            }
        }
    }
}