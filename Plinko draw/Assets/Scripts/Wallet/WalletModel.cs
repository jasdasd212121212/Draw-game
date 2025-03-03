using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class WalletModel : ISaveble<WalletSaveData>
{
    public int Money { get; private set; }

    public event Action dataChecnged;
    public event Action loaded;

    public void ChargeMoney(int money)
    {
        if (ValidateValue(money) == false)
        {
            return;
        }

        Money += money;

        dataChecnged?.Invoke();
    }

    public void DebitMoney(int money)
    {
        if (ValidateValue(money) == false)
        {
            return;
        }

        Money -= money;

        dataChecnged?.Invoke();
    }

    public async UniTask<WalletSaveData> GetData(bool isFirstLoad)
    {
        await UniTask.Delay(0);
        return new WalletSaveData(Money);
    }

    public void SetData(WalletSaveData data)
    {
        Money = data.Money;

        loaded?.Invoke();
    }

    private bool ValidateValue(int value)
    {
        if (value <= 0)
        {
            Debug.LogError($"Critical error -> invalid money value: {value}");
            return false;
        }

        return true;
    }
}