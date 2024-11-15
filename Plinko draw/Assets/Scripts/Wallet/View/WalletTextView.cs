using TMPro;
using UnityEngine;
using Zenject;

public class WalletTextView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    [Inject] private WalletModel _wallet;

    private void Awake()
    {
        _wallet.dataChecnged += Display;
        Display();
    }

    private void OnDestroy()
    {
        _wallet.dataChecnged -= Display;
    }

    private void Display()
    {
        _text.text = _wallet.Money.ToString();
    }
}