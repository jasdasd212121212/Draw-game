using System;
using UnityEngine;

[Serializable]
public class SkinSystemSaveData
{
    [SerializeField] private bool _hasSkin;
    [SerializeField] private int _currentSkinIndex;
    [SerializeField] private int[] _skinsIndexes;

    public bool HasSkin => _hasSkin;
    public int CurrentSkinIndex => _currentSkinIndex;
    public int[] SkinsIndexes => _skinsIndexes;

    public SkinSystemSaveData(bool hasSkin, int currentSkinIndex, int[] skins)
    {
        _hasSkin = hasSkin;
        _currentSkinIndex = currentSkinIndex;
        _skinsIndexes = skins;
    }
}