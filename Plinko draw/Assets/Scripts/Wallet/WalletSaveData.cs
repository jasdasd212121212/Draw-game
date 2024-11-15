using System;
using UnityEngine;

[Serializable]
public class WalletSaveData
{
    [SerializeField] private int _money;

    public int Money => _money;

    public WalletSaveData(int money)
    {
        _money = money;
    }
}