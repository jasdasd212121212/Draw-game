using TMPro;
using UnityEngine;

public class BonusTextView : MonoBehaviour
{
    [SerializeField] private PlinkoFinishBucket _presenter;
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _text.text = _presenter.SeflBonus.ToString();
    }
}