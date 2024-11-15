using System;

public class SkinShopPresenter
{
    private SkinShopSettings _settings;
    private SkinSystemModel _skinsSystemModel;
    private SkinShopModel _skinsShopModel;
    private WalletModel _wallet;

    public SkinShopSettingsDataNode CurrentSkin => _skinsShopModel.CurrentSkin;

    public event Action<SkinShopSettingsDataNode> currentChanged;
    public event Action modelLoaded;

    public SkinShopPresenter(SkinShopSettings settings, SkinSystemModel skinsSystemModel, SkinShopModel skinsShopModel, WalletModel wallet)
    {
        _settings = settings;
        _skinsSystemModel = skinsSystemModel;
        _skinsShopModel = skinsShopModel;
        _wallet = wallet;

        _skinsSystemModel.loaded += OnLoad;
    }

    ~SkinShopPresenter()
    {
        _skinsSystemModel.loaded -= OnLoad;
    }

    public bool SkinIsBuyed(SkinShopSettingsDataNode skin) => _skinsSystemModel.Contains(skin);

    public bool SkinIsChoosed(SkinShopSettingsDataNode skin)
    {
        if (skin == _settings.DefaultSkin && _skinsSystemModel.HasSkin == false)
        {
            return true;
        }
        else
        {
            return _skinsSystemModel.Contains(skin) && _settings.Nodes[_skinsSystemModel.CurrentSkinIndex] == skin && _skinsSystemModel.HasSkin == true;
        }
    }

    public void Next()
    {
        _skinsShopModel.Next();

        currentChanged?.Invoke(_skinsShopModel.CurrentSkin);
    }

    public void Previous()
    {
        _skinsShopModel.Previous();

        currentChanged?.Invoke(_skinsShopModel.CurrentSkin);
    }

    public void Choose()
    {
        if (SkinIsBuyed(_skinsShopModel.CurrentSkin) == false)
        {
            return;
        }

        _skinsShopModel.Select();

        currentChanged?.Invoke(_skinsShopModel.CurrentSkin);
    }

    public void Buy()
    {
        if (SkinIsChoosed(_skinsShopModel.CurrentSkin) == true || _wallet.Money < _skinsShopModel.CurrentSkin.Cost)
        {
            return;
        }

        _skinsShopModel.Buy();
        _wallet.DebitMoney(_skinsShopModel.CurrentSkin.Cost);

        currentChanged?.Invoke(_skinsShopModel.CurrentSkin);
    }

    private void OnLoad()
    {
        modelLoaded?.Invoke();
    }
}