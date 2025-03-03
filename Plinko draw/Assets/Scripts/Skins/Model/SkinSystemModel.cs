using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkinSystemModel : ISaveble<SkinSystemSaveData>
{
    private SkinShopSettings _settings;

    private bool _hasSkin = false;
    private int _currentSkinIndex;
    private List<int> _skinsIndexes = new List<int>();

    public event Action dataChecnged;
    public event Action loaded;

    public Sprite CurrentSkin
    {
        get
        {
            Sprite sprite = _settings.Nodes[_currentSkinIndex].Skin;

            if (_hasSkin == true)
            {
                return sprite;
            }
            else
            {
                return _settings.DefaultSkin.Skin;
            }
        }
    }

    public IReadOnlyList<int> SkinsIndexes => _skinsIndexes;
    public bool HasSkin => _hasSkin;
    public int CurrentSkinIndex => _currentSkinIndex;

    public SkinSystemModel(SkinShopSettings settings)
    {
        _settings = settings;
    }

    public void AddSkin(SkinShopSettingsDataNode skin)
    {
        int index = _settings.IndexOf(skin);

        if (index >= 0)
        {
            _skinsIndexes.Add(index);
        }

        dataChecnged?.Invoke();
    }

    public void SelectSkin(SkinShopSettingsDataNode skin)
    {
        if (skin == null || skin == _settings.DefaultSkin)
        {
            _hasSkin = false;
            _currentSkinIndex = 0;

            dataChecnged?.Invoke();
            return;
        }

        int index = _settings.IndexOf(skin);

        if (index >= 0)
        {
            if (_skinsIndexes.Contains(index))
            {
                _currentSkinIndex = index;
                _hasSkin = true;
            }
            else
            {
                Debug.LogError($"Critical error -> Can`t select not byed skin");
            }
        }

        dataChecnged?.Invoke();
    }

    public bool Contains(SkinShopSettingsDataNode skin)
    {
        if (skin == _settings.DefaultSkin)
        {
            return true;
        }

        int index = _settings.IndexOf(skin);

        if (index >= 0)
        {
            return _skinsIndexes.Contains(index);
        }

        return false;
    }

    public async UniTask<SkinSystemSaveData> GetData(bool isFirstLoad)
    {
        await UniTask.Delay(0);
        return new SkinSystemSaveData(_hasSkin, _currentSkinIndex, _skinsIndexes.ToArray());
    }

    public void SetData(SkinSystemSaveData data)
    {
        _hasSkin = data.HasSkin;
        _currentSkinIndex = data.CurrentSkinIndex;
        _skinsIndexes = data.SkinsIndexes.ToList();

        loaded?.Invoke();   
    }
}