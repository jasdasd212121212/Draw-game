using UnityEngine.UI;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Button))]
public class RewardAdsButtonView : MonoBehaviour
{
    [Inject] private AdsRewardButtonModel _model;

    private Button _selfButton;

    private void Awake()
    {
        _selfButton = GetComponent<Button>();
        _selfButton.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        _selfButton.onClick.RemoveAllListeners();
    }

    private void OnClick()
    {
        _model.GetReward();
    }
}