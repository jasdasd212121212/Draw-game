public class AdsRewardButtonModel
{
    private IAdsFacade _ads;
    private WalletModel _wallet;

    public int Reward { get; private set; }

    public AdsRewardButtonModel(IAdsFacade ads, int reward, WalletModel wallet)
    {
        _ads = ads;
        Reward = reward;
        _wallet = wallet;
    }

    public void GetReward()
    {
        _ads.ShowRewardedAds(() => 
        {
            _wallet.ChargeMoney(Reward);
        });
    }
}