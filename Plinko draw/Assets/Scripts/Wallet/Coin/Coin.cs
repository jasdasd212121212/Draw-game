using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    [SerializeField][Min(1)] private int _cost = 10;

    [Inject] private WalletModel _wallet;

    public event Action collected;

    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerBall>() != null)
        {
            collected?.Invoke();

            _wallet.ChargeMoney(_cost);
            Destroy(gameObject);
        }
    }
}