using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LineDrawAmountView : MonoBehaviour
{
    [SerializeField] private Image _fillImage;

    [Inject] private LineDrawerAmountModel _model;

    private void Awake()
    {
        _model.amountChanged += Display;
        Display();
    }

    private void OnDestroy()
    {
        _model.amountChanged -= Display;
    }

    private void Display()
    {
        _fillImage.fillAmount = (float)((float)_model.Amount / (float)_model.MaximalAmount);
    }
}