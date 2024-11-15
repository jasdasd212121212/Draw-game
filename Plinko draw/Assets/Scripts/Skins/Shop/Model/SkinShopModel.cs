using System;

public class SkinShopModel
{
    private SkinShopSettingsDataNode[] _skins;
    private SkinSystemModel _skinsSystem;

    public int CurrentSkinIndex { get; private set; }
    public SkinShopSettingsDataNode CurrentSkin => _skins[CurrentSkinIndex];

    public SkinShopModel(SkinShopSettingsDataNode[] skins, SkinSystemModel skinsSystem)
    {
        _skins = skins;
        _skinsSystem = skinsSystem;
    }

    public void Next()
    {
        if ((CurrentSkinIndex + 1) >= _skins.Length)
        {
            CurrentSkinIndex = 0;
        }
        else
        {
            CurrentSkinIndex++;
        }
    }

    public void Previous()
    {
        if ((CurrentSkinIndex - 1) < 0)
        {
            CurrentSkinIndex = _skins.Length - 1;
        }
        else
        {
            CurrentSkinIndex--;
        }
    }

    public void Buy()
    {
        _skinsSystem.AddSkin(_skins[CurrentSkinIndex]);
    }

    public void Select()
    {
        _skinsSystem.SelectSkin(_skins[CurrentSkinIndex]);
    }
}