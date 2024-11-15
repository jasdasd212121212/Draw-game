using TMPro;
using UnityEngine;
using Zenject;

public class PlinkoScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    [Inject] private PlinkoBonusModel _model;

    private void OnEnable()
    {
        _text.text = _model.TotalRevenue.ToString();
    }
}