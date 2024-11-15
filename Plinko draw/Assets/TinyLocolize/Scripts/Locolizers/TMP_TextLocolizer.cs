using UnityEngine;
using TMPro;
using Cysharp.Threading.Tasks;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TMP_TextLocolizer : MonoBehaviour
{
    [SerializeField] private bool _setOnStart = true;
    private TextMeshProUGUI _text;

    private string _textKey;

    public string text
    {
        set
        {
            SetText(value).Forget();
        }
    }

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _textKey = _text.text;

        LocolizeSettingObservableFacade.languageChanged += OnLocalChanged;

        if (_setOnStart == true)
        {
            OnLocalChanged();
        }
    }

    private void OnDestroy()
    {
        LocolizeSettingObservableFacade.languageChanged -= OnLocalChanged;
    }

    private void OnLocalChanged()
    {
        SetText(_textKey).Forget();
    }

    public async UniTask SetText(string key)
    {
        if (_text == null)
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        _textKey = key;
        _text.text = await LocolizeSystemFacade.GetLoclized(key);
    }
}