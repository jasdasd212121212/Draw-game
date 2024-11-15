using UnityEngine;

[RequireComponent(typeof(Coin))]
public abstract class CoinViewBase : MonoBehaviour
{
    private Coin _coin;

    protected void Awake()
    {
        _coin = GetComponent<Coin>();
        _coin.collected += OnCollect;
    }

    protected void OnDestroy()
    {
        _coin.collected -= OnCollect;
    }

    protected abstract void OnCollect();
}