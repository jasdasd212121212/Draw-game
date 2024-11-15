using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public class RewardButtonTextView : MonoBehaviour
{
    [SerializeField] private string _locolizeKey;

    [Inject] private AdsRewardButtonModel _model;

    private void Awake()
    {
        LocolizeSettingObservableFacade.languageChanged += OnChange;
        OnChange();
    }

    private void OnDestroy()
    {
        LocolizeSettingObservableFacade.languageChanged -= OnChange;
    }

    private void OnChange()
    {
        Display().Forget();
    }

    private async UniTask Display()
    {
        string locolized = await LocolizeSystemFacade.GetLoclized(_locolizeKey);
        GetComponent<TextMeshProUGUI>().text = string.Format(locolized, _model.Reward);
    }
}