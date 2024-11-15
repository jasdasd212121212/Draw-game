using UnityEngine;

public class PlinkoEndedState : State
{
    private WalletModel _wallet;
    private PlinkoBonusModel _model;

    private bool _isCharged;

    public PlinkoEndedState(WalletModel wallet, PlinkoBonusModel model)
    {
        _wallet = wallet;
        _model = model;
    }

    public override void OnEnter()
    {
        if (_isCharged == true)
        {
            Debug.LogWarning($"You try to enter used state");
            return;
        }

        _wallet.ChargeMoney(_model.TotalRevenue);
        _isCharged = true;
    }
}